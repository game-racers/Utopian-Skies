using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{

    public int Cost;
    public float HappinessMod;
    public float SecurityMod;
    public int FreedomMod;
    public int ProsperityMod;

    public bool needsRoad;


    public GameObject previewObject;
    public Vector3 offset;

    public GameObject getpreview()
    {
        return previewObject;
    }

    public Vector3 returnup()
    {
        return offset;
    }

    public int GetCost()
    {
        return Cost;
    }

    public float GetHappMod()
    {
        return HappinessMod;
    }

    public float GetSecMod()
    {
        return SecurityMod;
    }


    public bool GetNeedsRoad()
    {
        return needsRoad;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
