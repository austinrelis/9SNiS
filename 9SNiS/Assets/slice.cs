using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class slice : MonoBehaviour
{
    LineRenderer line;
    Vector2 mousePos;

    // initializes linerenderer parameters
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // runs every frame
    void Update()
    {
        // if mousekey pressed
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, mousePos);
        }
        else
        {
               line.SetVertexCount(0);
        }

    }

}
