using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform ObjA;
    public Transform ObjB;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    
    void Update()
    {
        line.SetPosition(0, ObjA.position);
        line.SetPosition(1, ObjB.position);
    }
}
