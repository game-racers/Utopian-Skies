using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int gridwidth, gridheight;
    private Vector3[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    private void Generate ()
    {
        vertices = new Vector3[(gridwidth + 1) * (gridheight + 1)];
        for (int i = 0, y= 0, z = 0; z <= gridheight; z++)
        {
            for (int x = 0; x <= gridwidth; x++, i++)
            {
                vertices[i] = new Vector3(x, y, z);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i<vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

}
