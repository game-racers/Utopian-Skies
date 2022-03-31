using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileOverChange : MonoBehaviour
{
    private Renderer render;
    public Color groundcolor = new Color(0f, 156f, 0f);
    public Color selectcolor = new Color(25f, 123f, 48f);

    //merging PlaceObject with TileOverControls
    public GameObject building;
    public Vector3 offset;
    public GameObject tile;
    //public Material previewmat;
    public GameObject previewbuilding;
    
    private PlaceObject objectmanager;
    private GameObject citymanager;
    public bool isPreviewing = false;


    void Start()
    {
        citymanager = GameObject.Find("CityManager");
        objectmanager = citymanager.GetComponent<PlaceObject>();
        render = gameObject.GetComponent<Renderer>();

    }
    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseOver()
    {
        if (objectmanager.previewbuilding != null)
        {
            building = objectmanager.ReturnBuild();
            if (this.isPreviewing == false)
            {
                if (objectmanager.getBuildMode() == true)
                {
                    previewbuilding = Instantiate(building, this.transform.position + offset, Quaternion.identity);
                    isPreviewing = true;
                }

            }
        }
        render.material.color = selectcolor;
    }

    void OnMouseExit()
    {
        render.material.color = groundcolor;
        Destroy(previewbuilding);
        isPreviewing = false;
    }
}
