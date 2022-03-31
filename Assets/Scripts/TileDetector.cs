using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDetector : MonoBehaviour
{
    public Vector3 test;
    public Collider[] adjacent;

    //test stuff
    public LayerMask testMask;

    public GameObject North;
    public GameObject South;
    public GameObject West;
    public GameObject East;

    public GameObject Debugtile;

    void Start()
    {
        North = Debugtile;
        South = Debugtile;
        East = Debugtile;
        West = Debugtile;
        DetectAdjacent();
        //    Collider[] adjacent = Physics.OverlapSphere(test, 5);
    }

    public void DetectAdjacent()
    {
        adjacent = Physics.OverlapSphere(this.transform.position, 5);
        foreach (Collider i in adjacent)
        {
            if (i.transform.position.z < this.transform.position.z && i.tag == "Tile")
            {
                North = i.gameObject;
            }
            else if (i.transform.position.z > this.transform.position.z && i.tag == "Tile")
            {
                South = i.gameObject;
            }
            else if (i.transform.position.x < this.transform.position.x && i.tag == "Tile")
            {
                West = i.gameObject;
            }
            else if (i.transform.position.x > this.transform.position.x && i.tag == "Tile")
            {
                East = i.gameObject;
            }

        }
    }


    //z-axis determines north/south
    //x-axis determines east/west

    // Update is called once per frame
    void Update()
    {


        //var nonadject = Physics.OverlapSphere(this.transform.position, 25, testMask);
    }

    public GameObject GetTile()
    {
        return this.transform.gameObject;
    }

    public GameObject GetNorth()
    {
        return North;
    }

    public GameObject GetSouth()
    {
        return South;
    }

    public GameObject GetWest()
    {
        return West;
    }

    public GameObject GetEast()
    {
        return East;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, 5);
    }


    public bool GetHouse()
    {
        if (North != null && North.GetComponentInChildren<HouseMarker>() != null)
        {
            return true;
        }
        else if (South != null && South.GetComponentInChildren<HouseMarker>() != null)
        {
            return true;
        }
        else if (West != null && West.GetComponentInChildren<HouseMarker>() != null)
        {
            return true;
        }
        else if (East != null && East.GetComponentInChildren<HouseMarker>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        //check if north / south / east / west have houses on them

    }


    public GameObject GetClose()
    {
        if (North != null && North.GetComponentInChildren<Road>() != null)
        {
            return GetNorth();
        }
        else if (South != null && South.GetComponentInChildren<Road>() != null)
        {
            return GetSouth();
        }
        else if (West != null && West.GetComponentInChildren<Road>() != null)
        {
            return GetWest();
        }
        else if (East != null && East.GetComponentInChildren<Road>() != null)
        {
            return GetEast();
        }
        else
        {
            return Debugtile;
        }
    }

    public void DelRoadUpdate()
    {
        if (North != null && North.GetComponentInChildren<Road>() != null && South != null && South.GetComponentInChildren<Road>() != null && West != null && West.GetComponentInChildren<Road>() != null && East != null && East.GetComponentInChildren<Road>() != null)
            {
            North.GetComponentInChildren<Road>().RoadUpdate();
            South.GetComponentInChildren<Road>().RoadUpdate();
            West.GetComponentInChildren<Road>().RoadUpdate();
            East.GetComponentInChildren<Road>().RoadUpdate();
        }
        else if (North != null && North.GetComponentInChildren<Road>() != null && South != null && South.GetComponentInChildren<Road>() != null && East != null && East.GetComponentInChildren<Road>() != null)
        {
            North.GetComponentInChildren<Road>().RoadUpdate();
            South.GetComponentInChildren<Road>().RoadUpdate();
            East.GetComponentInChildren<Road>().RoadUpdate();
        }

        else if (North != null && North.GetComponentInChildren<Road>() != null && South != null && South.GetComponentInChildren<Road>() != null && West != null && West.GetComponentInChildren<Road>() != null)
        {
            North.GetComponentInChildren<Road>().RoadUpdate();
            South.GetComponentInChildren<Road>().RoadUpdate();
            West.GetComponentInChildren<Road>().RoadUpdate();
        }

        else if (North != null && North.GetComponentInChildren<Road>() != null && South != null && South.GetComponentInChildren<Road>() != null)
        {
            North.GetComponentInChildren<Road>().RoadUpdate();
            South.GetComponentInChildren<Road>().RoadUpdate();
        }
        else if (West != null && West.GetComponentInChildren<Road>() != null && East != null && East.GetComponentInChildren<Road>() != null)
        {
            East.GetComponentInChildren<Road>().RoadUpdate();
            West.GetComponentInChildren<Road>().RoadUpdate();
        }

        else if (North != null && North.GetComponentInChildren<Road>() != null)
        {
            North.GetComponentInChildren<Road>().RoadUpdate();
        }
        else if (South != null && South.GetComponentInChildren<Road>() != null)
        {
            South.GetComponentInChildren<Road>().RoadUpdate();
        }
        else if (West != null && West.GetComponentInChildren<Road>() != null)
        {
            West.GetComponentInChildren<Road>().RoadUpdate();
        }
        else if (East != null && East.GetComponentInChildren<Road>() != null)
        {
            East.GetComponentInChildren<Road>().RoadUpdate();
        }
        else
        {
            Debug.Log("Not a road TileDetector");
        }
    }
}
