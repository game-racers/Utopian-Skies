using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CustomObj", menuName = "Settings", order = 1)]

public class GameSettings : ScriptableObject
{
    public bool TutMode;
    public int VolumeLevel;
    public int MapX;
    public int MapY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
