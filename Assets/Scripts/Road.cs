using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    private TileDetector tiles;
    public GameObject crossprefab;
    public GameObject tprefab;
    public GameObject rtprefab;
    public GameObject lprefab;
    public GameObject lprefab2;
    public GameObject lprefab3;
    public GameObject lprefab4;
    public GameObject baseprefab;
    public GameObject st1prefab;
    public GameObject uproad;
    public GameObject st2prefab;
    public bool hasHouses;
    public Transform[] LeftWaypoints;
    public Transform[] RightWaypoints;
    public CarSpawner spawn;

    public int otherDirs;

    public Transform[] LeftWaypoints2;
    public Transform[] RightWaypoints2;

    public Transform[] LeftWaypoints3;
    public Transform[] RightWaypoints3;

    public List<Road> connectRoads;



    // Start is called before the first frame update
    void Start()
    {
        //tiles = transform.parent.gameObject.GetComponent<TileDetector>();
        //tiles.DetectAdjacent();
        //var NorthRoad = tiles.GetNorth().GetComponentInChildren<Road>();
        //var SouthRoad = tiles.GetSouth().GetComponentInChildren<Road>();
        //var EastRoad = tiles.GetEast().GetComponentInChildren<Road>();
        //var WestRoad = tiles.GetWest().GetComponentInChildren<Road>();
        //connectRoads.Add(NorthRoad);
        //connectRoads.Add(SouthRoad);
        //connectRoads.Add(EastRoad);
        //connectRoads.Add(WestRoad);

    }



    
    public void RoadUpdate()
    {
        tiles = transform.parent.gameObject.GetComponent<TileDetector>();
        tiles.DetectAdjacent();

        var NorthNull = tiles.GetNorth();
        var SouthNull = tiles.GetSouth();
        var EastNull = tiles.GetEast();
        var WestNull = tiles.GetWest();

        //new stuff, if something breaks, it's because of this.

        connectRoads.Clear();
        connectRoads.Add(NorthNull.GetComponentInChildren<Road>());
        connectRoads.Add(SouthNull.GetComponentInChildren<Road>());
        connectRoads.Add(EastNull.GetComponentInChildren<Road>());
        connectRoads.Add(WestNull.GetComponentInChildren<Road>());



        if (NorthNull != null && SouthNull != null && EastNull != null && WestNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetSouth().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && SouthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
                Instantiate(crossprefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
                //crossprefab.GetComponent<Road>().EdgeCheck();
                Destroy(this.gameObject);
        }
        else if (NorthNull != null && EastNull != null && WestNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
                Instantiate(tprefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
                //tprefab.GetComponent<Road>().EdgeCheck();
                Destroy(this.gameObject);
        }
        else if (SouthNull != null && EastNull != null && WestNull != null && tiles.GetSouth().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0
            && SouthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
                Instantiate(rtprefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
                //rtprefab.GetComponent<Road>().EdgeCheck();
                Destroy(this.gameObject);
        }
        else if (NorthNull != null && SouthNull != null && EastNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetSouth().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && SouthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(st1prefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //st1prefab.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (NorthNull != null && SouthNull != null && WestNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetSouth().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && SouthNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(st2prefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //st2prefab.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (SouthNull != null && EastNull != null && tiles.GetSouth().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0
            && SouthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(lprefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //lprefab.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (SouthNull != null && WestNull != null && tiles.GetSouth().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0
           && SouthNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(lprefab2, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //lprefab2.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (NorthNull != null && WestNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetWest().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && WestNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(lprefab3, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //lprefab3.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (NorthNull != null && EastNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetEast().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && EastNull.GetComponentInChildren<Road>())
        {
            Instantiate(lprefab4, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //lprefab4.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (NorthNull != null && SouthNull != null && tiles.GetNorth().transform.childCount > 0 && tiles.GetSouth().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null && SouthNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(uproad, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            uproad.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (NorthNull != null && tiles.GetNorth().transform.childCount > 0
            && NorthNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(uproad, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            uproad.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else if (SouthNull != null && tiles.GetSouth().transform.childCount > 0 && SouthNull.GetComponentInChildren<Road>() != null)
        {
            Instantiate(uproad, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            uproad.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(baseprefab, tiles.GetTile().transform.position, Quaternion.identity, tiles.GetTile().transform);
            //baseprefab.GetComponent<Road>().EdgeCheck();
            Destroy(this.gameObject);
        };
    }

    public void EdgeCheck()
    {
        spawn.EnableSpawn();
    }


    public void SideRoadUpdate()
    {
        if (tiles.GetNorth().transform.childCount > 0)
        {
            Road north = tiles.GetNorth().GetComponentInChildren<Road>();
            //north.GetComponent<Road>().EdgeCheck();
            if (north != null)
            {
                north.RoadUpdate();
            }
        }
        if (tiles.GetSouth().transform.childCount > 0)
        {
            Road south = tiles.GetSouth().GetComponentInChildren<Road>();
            //south.GetComponent<Road>().EdgeCheck();
            if (south != null)
            {
                south.RoadUpdate();
            }
            //south.RoadUpdate();
        }
        if (tiles.GetEast().transform.childCount > 0)
        {
            Road east = tiles.GetEast().GetComponentInChildren<Road>();
            //east.GetComponent<Road>().EdgeCheck();
            if (east != null)
            {
                east.RoadUpdate();
            }
            //east.RoadUpdate();
        }
        if (tiles.GetWest().transform.childCount > 0)
        {
            Road west = tiles.GetWest().GetComponentInChildren<Road>();
            //west.GetComponent<Road>().EdgeCheck();
            if (west != null)
            {
                west.RoadUpdate();
            }
            //west.RoadUpdate();
        }

        EdgeCheck();
    }


    //can't use collisions roads dont use colliders
   void OnCollisionEnter (Collision collision)
    {
        tiles = transform.parent.gameObject.GetComponent<TileDetector>();
        tiles.DetectAdjacent();

        var NorthNull = tiles.GetNorth();
        var SouthNull = tiles.GetSouth();
        var EastNull = tiles.GetEast();
        var WestNull = tiles.GetWest();

        if (collision.gameObject.tag == "Car" && collision.gameObject.GetComponent<CarAI>().waypoints[0] != null)
        {
            collision.gameObject.GetComponent<CarAI>().setLastRoad(collision.gameObject.GetComponent<CarAI>().waypoints[0].parent.gameObject.GetComponent<Road>());
        }

        if (collision.gameObject.tag == "Car" && collision.gameObject.GetComponent<CarAI>().side == true)
        {
            if (otherDirs == 1)
            {
                var dirChoose = Random.Range(0, 1);
                if (dirChoose == 0)
                {
                    Debug.Log("We on the left yall");
                    collision.gameObject.GetComponent<CarAI>().SetWaypoints(LeftWaypoints);
                }
                else
                {
                    Debug.Log("We on the left yall");
                    collision.gameObject.GetComponent<CarAI>().SetWaypoints(LeftWaypoints2);
                }

            }
            else
            {
                //Debug.Log(collision);
                collision.gameObject.GetComponent<CarAI>().SetWaypoints(LeftWaypoints);
            }

        }
        if (collision.gameObject.tag == "Car" && collision.gameObject.GetComponent<CarAI>().side == false)
        {
            //if multiple directions
            //assign it a connected road that is not the one it ccame from
            //check where the car is coming from and tht the destination is not the same
            //feed it the waypoints of that road
            //update references
            if (otherDirs == 1)
            {
                //Debug.Log("Otherdirs registering" + otherDirs);
                var dirChoose = Random.Range(0, 2);
                //Debug.Log("dirchoose choice " + dirChoose);
                if (dirChoose == 0)
                {
                    if (RightWaypoints[0].parent.GetComponent<Road>() == collision.gameObject.GetComponent<CarAI>().lastRoad)
                    {
                        dirChoose = Random.Range(0, 2);
                    }
                    //.Log("Waypoints 1");
                    collision.gameObject.GetComponent<CarAI>().SetWaypoints(RightWaypoints);
                    collision.gameObject.GetComponent<CarAI>().setLastRoad(this);
                }
                else
                {
                    //Debug.Log("Waypoints 2");
                    collision.gameObject.GetComponent<CarAI>().SetWaypoints(RightWaypoints2);
                    collision.gameObject.GetComponent<CarAI>().setLastRoad(this);
                }
            }
            else
            {
                //Debug.Log(collision);
                collision.gameObject.GetComponent<CarAI>().SetWaypoints(RightWaypoints);
                collision.gameObject.GetComponent<CarAI>().setLastRoad(this);
            }

        }
        //new stuff (might break things)
        if (collision.gameObject.tag == "Road")
        {
            tiles = transform.parent.gameObject.GetComponent<TileDetector>();
            tiles.DetectAdjacent();

            //Add these to an array
            //Randomly select one
            // Check it against lastRoad if the same redraw.
            //redo waypoonts ;_;

            Debug.Log(connectRoads[0]);
            Debug.Log(connectRoads[1]);
            Debug.Log(connectRoads[2]);
            Debug.Log(connectRoads[3]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tiles != null)
        {
            EdgeCheck();
        }

    }

}
