using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CarAI : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Road lastRoad;
    public Transform[] waypoints;
    public bool side;

    public int m_CurrentWaypointIndex;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am here.");
        DOTween.Init();
        //side = true;
        if (waypoints[0] != null)
        {
            navMeshAgent.SetDestination(waypoints[0].position);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length != 0)
        {
            if (waypoints[0] != null)
            {
                if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                {
                    navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                    m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;

                }

            }
            //currentroad = Physics.OverlapSphere(this.transform.position, 1);
        }

    }

    public void SetWaypoints(Transform[] nupoints)
    {
        waypoints = null;
        waypoints = nupoints;

    }

    public void OnTriggerExit(Collider switchside)
    //public void OnCollisionExit(Collision switchside)
    {
        StartCoroutine(Decision());

        IEnumerator Decision()
        {

            if (switchside.transform.tag == "Switch" && side == true)
            {
                //Debug.Log("false");
                side = false;
            }
            else if (switchside.transform.tag == "Switch" && side == false)
            {
                //Debug.Log("true");
                side = true;
            }
            yield return new WaitForSeconds(.2f);
        }

    }

    public Road getLastRoad()
    {
        return lastRoad;
    }

    public void setLastRoad(Road newRoad)
    {
        lastRoad = newRoad;
    }


}
