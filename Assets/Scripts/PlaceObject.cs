using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlaceObject : MonoBehaviour
{
    public GameObject building;
    public Vector3 offset;
    public GameObject tile;
    public Material previewmat;
    public CityStats citystat;
    public bool buildmode;
    public GameObject previewbuilding;
    Ray mouseray;
    RaycastHit hit;

    public DialogueManager dialManage;
    public GameSettings settingMan;
    public DialogueTriggers dTrigger;




    //testing purposes

    void Start()
    {
        //offset = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (mouseray, out hit))
        {
            tile = hit.collider.gameObject;
        }
        else
        {
            tile = null;
        }


        if (Input.GetMouseButtonDown(0) && buildmode == false && !EventSystem.current.IsPointerOverGameObject())
        {
            foreach (Transform child in tile.transform)
            {
                //Mark road as dependent when house is built, check that when delete is attempted.
                if (child.gameObject.GetComponent<Road>() != null)
                {
                    //Destroy Object Code
                    if (tile.GetComponent<TileDetector>().GetHouse() == false)
                    {
                        DestroyImmediate(child.gameObject);

                        tile.GetComponent<TileDetector>().DelRoadUpdate();
                    }
                    else
                    {
                        //give error message to player that road still has houses attached..
                        Debug.Log("Temporary Error Message");
                    }

                }
                else if (child.gameObject.tag == "House")
                {
                    citystat.addMoney(child.gameObject.GetComponent<Buildable>().Cost / 2);
                    previewbuilding = null;
                    Destroy(child.gameObject);

                }
                else
                {
                    previewbuilding = null;
                    Destroy(child.gameObject);
                    citystat.addMoney(10);

                }
            }
        }
        // if they're in build mode
        else if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && buildmode == true && previewbuilding != null)
        {
            //new stuff helps triggering dialogue
            if (building.GetComponent<Road>() != null && settingMan.TutMode == true && dialManage.tutcheck[0] != true)
            {
                dialManage.tutcount += 1;
                dTrigger.PlayTut();
                dialManage.tutcheck[0] = true;
            }
            if (building.tag == "House" && settingMan.TutMode == true)
            {
                dialManage.tutcount += 1;
                dTrigger.PlayTut();
            }
            if (building.tag == "SBusiness" && settingMan.TutMode == true)
            {
                dialManage.tutcount += 1;
                dTrigger.PlayTut();
            }






            tile.GetComponent<TileDetector>().DetectAdjacent();
            if (building.GetComponent<Buildable>().GetNeedsRoad() == true && (tile.GetComponent<TileDetector>().GetWest().GetComponentInChildren<Road>() != null 
                || tile.GetComponent<TileDetector>().GetNorth().GetComponentInChildren<Road>() != null || tile.GetComponent<TileDetector>().GetSouth().GetComponentInChildren<Road>() != null
                || tile.GetComponent<TileDetector>().GetEast().GetComponentInChildren<Road>() != null))
            {

                //change to instantiate as a child of the tile
                if (tile.transform.childCount < 1)
                {
                    offset = building.GetComponent<Buildable>().returnup();
                    GameObject build = Instantiate(building, tile.transform.position + offset, Quaternion.identity);
                    var lookdir = tile.GetComponent<TileDetector>().GetClose().GetComponent<Transform>().position;
                    Vector3 targetposition = new Vector3(lookdir.x, 0, lookdir.z);
                    build.GetComponent<Transform>().LookAt(targetposition);
                    build.GetComponent<Transform>().Rotate(0, 90, 0);
                    //build.GetComponent<Transform>().rotation = (0, 0 ,0);


                    //LookRotation(tile.GetComponent<TileDetector>().GetClose().GetComponentInChildren<Transform>().position)
                    build.transform.parent = tile.transform;
                    CityStats stats = Object.FindObjectOfType<CityStats>();
                    stats.loseMoney(building.GetComponent<Buildable>().GetCost());


                    //Increase the Maximum Population of the City by 3 per house.
                    int increase = 0;
                    switch (build.name)
                    {
                        case "BaseHouse(Clone)":
                            increase = 2;
                            break;
                        case "LargeHouse(Clone)":
                            increase = 3;
                            break;
                        case "Apartment(Clone)":
                            increase = 20;
                            break;
                        default:
                            break;
                    }
                    stats.increaseMaxPop(increase);

                    if (building.GetComponent<Road>() != null)
                    {
                        Road roadref = build.GetComponent<Road>();
                        roadref.RoadUpdate();
                        roadref.SideRoadUpdate();
                    }
                }
            }
            else if (building.GetComponent<Buildable>().GetNeedsRoad() == false)
            {
                if (tile.transform.childCount < 1)
                {
                    //checking if debt limit is reached when building object.
                    if ((citystat.money - building.GetComponent<Buildable>().GetCost()) < citystat.debtLimit && dialManage.govdial != null)
                    {
                        Debug.Log("Cannot build since you don't have enough money");
                        //Code for status bar message / reaction to trying to build without money goes here.
                        //dialManage.StartDialogue(dialManage.govdial[dialManage.govcount]);
                        //dialManage.govcheck[dialManage.govcount] = true;
                        //dialManage.govcount += 1;
                    }
                    else
                    {
                        offset = building.GetComponent<Buildable>().returnup();
                        GameObject build = Instantiate(building, tile.transform.position + offset, Quaternion.identity);
                        build.transform.parent = tile.transform;
                        CityStats stats = Object.FindObjectOfType<CityStats>();
                        stats.loseMoney(building.GetComponent<Buildable>().GetCost());

                        if (building.GetComponent<Road>() != null)
                        {
                            Road roadref = build.GetComponent<Road>();
                            roadref.RoadUpdate();
                            roadref.SideRoadUpdate();
                            NavMeshLink[] links = FindObjectsOfType<NavMeshLink>();
                            foreach (NavMeshLink b in links)
                            {
                                b.UpdateLink();
                            }
                        }
                    }
                }
            }



        }
    }

    public bool getBuildMode()
    {
        return this.buildmode;
    }

    public void setBuildMode(bool input)
    {
        buildmode = input;
    }

    public void SetObject(GameObject newbuild)
    {
        building = newbuild;
        previewbuilding = newbuild.GetComponent<Buildable>().getpreview();
        offset = newbuild.GetComponent<Buildable>().returnup();
    }

    public GameObject ReturnTile()
    {
        return tile;
    }

    public GameObject ReturnBuild()
    {
        return previewbuilding;
    }
}


