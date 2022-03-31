using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarSpawner : MonoBehaviour
{

    public float Timer = 10f;
    public float countTimer = 15f;
    public GameObject car;
    public UnityEngine.AI.NavMeshAgent carAgent;
    public GameObject carClone;
    public bool Spawnzone;
    public CityStats citynums;

    public CarAI[] carslist;

    // Start is called before the first frame update
    void Start()
    {
        citynums = FindObjectOfType<CityStats>();
    }

    public void EnableSpawn()
    {
        Spawnzone = true;
    }

    // Update is called once per frame
    void Update()
    {

        countTimer -= Time.deltaTime;
        if (countTimer <= 0f)
        {
            carslist = FindObjectsOfType<CarAI>();
            countTimer = 10f;
        }


        if (Spawnzone == true && carslist.Length <= citynums.populationCount)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                carClone = Instantiate(car, transform.position, transform.rotation);
                carAgent = carClone.GetComponent<NavMeshAgent>();
                carAgent.Warp(transform.position);
                Timer = 30f;

            }
        }
        else
        {
         //   Debug.Log("Update " + Spawnzone);
        }

    }
}
