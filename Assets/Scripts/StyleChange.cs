using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleChange : MonoBehaviour
{
    public GameObject controller;
    private CityStats stats;
    public GameObject buildingon;
    public Mesh[] mafiastyle;
    private int stage = 0;
    private MeshFilter buildmesh;

    // Start is called before the first frame update
    void Start()
    {
        buildingon = this.gameObject;
        buildmesh = this.gameObject.GetComponentInChildren<MeshFilter>();
        stats = controller.GetComponent<CityStats>();

    }

    // Update is called once per frame
    void Update()
    {
        //check citystats
        //triggers based off of policy passed / city stats
        //if trigger true after X time change style
        if (Input.GetKeyDown("o") && stage <= mafiastyle.Length-2)
        {

            buildingon = this.gameObject;
            stage = stats.getStage();
            stats.setStage(stage+1);
            buildmesh.mesh = mafiastyle[stage];

        }

    }
}
