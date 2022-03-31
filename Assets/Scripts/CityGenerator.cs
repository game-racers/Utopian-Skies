using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public int vertical;
    public int horizontal;
    public GameObject[] tiles;
    public GameObject outTile;
    public GameObject BorderObj;
    public float offset;
    public float largeoffset;
    public Vector3 origin = Vector3.zero;
    public GameSettings settingController;
    
    // Start is called before the first frame update
    void Start()
    {
        vertical = settingController.MapX;
        horizontal = settingController.MapY;
        largeoffset = vertical * 10;
        Create();
    }

    void Create()
    {
        for (int x = 0; x < vertical; x++)
        {
            for (int y = 0; y < horizontal; y++)
            {
                Vector3 spawnpos = new Vector3(x * offset, 0, y * offset);
                chooseTile(spawnpos, Quaternion.identity);
            }
        }
        for (int x = 0; x <= 2; x++)
        {
            for (int y = 0; y <= 2; y++)
            {
                if (x == 2 || x == 0 || y == 0 || y == 2)
                {
                    Vector3 spawnpos = new Vector3(x * largeoffset - (5*vertical+5), 0, y * largeoffset - (5*horizontal+5)) + origin;
                    LargeTile(spawnpos, Quaternion.identity);
                }
                if (x == 2)
                {
                    Vector3 borderpos = new Vector3(x * largeoffset/2 - 5, 0, y * largeoffset / 2);
                    Borders(borderpos, Quaternion.Euler(90, 0, 90));
                }
                if (x == 0)
                {
                    Vector3 borderpos = new Vector3(x * largeoffset - 5, 0, y * largeoffset / 2);
                    Borders(borderpos, Quaternion.Euler(90, 0, -90));
                }
                if (y == 0)
                {
                    Vector3 borderpos = new Vector3(x * largeoffset, 0, y * largeoffset / 2 - 5);
                    Borders(borderpos, Quaternion.Euler(90, 0, 0));
                }
                if (y == 2)
                {
                    Vector3 borderpos = new Vector3(x * largeoffset, 0, y * largeoffset / 2 - 5);
                    Borders(borderpos, Quaternion.Euler(90, 0, 180));
                }
            }
        }


    }

    void chooseTile(Vector3 posspawn, Quaternion spawnrot)
    {
        int random = Random.Range(0, tiles.Length);
        GameObject clone = Instantiate(tiles[random], posspawn, spawnrot);
    }

    void LargeTile(Vector3 posspawn, Quaternion spawnrot)
    {
        GameObject clone = Instantiate(outTile, posspawn, spawnrot);
        clone.transform.localScale = new Vector3(horizontal, 1, vertical);
    }

    void Borders(Vector3 posspawn, Quaternion spawnrot)
    {
        GameObject clone = Instantiate(BorderObj, posspawn, spawnrot);
        //GameObject clone2 = Instantiate(BorderObj, posspawn, Quaternion.Euler(90,90,0));
        clone.transform.localScale = new Vector3(horizontal, 1, vertical);
        //clone2.transform.localScale = new Vector3(horizontal, 1, vertical);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
