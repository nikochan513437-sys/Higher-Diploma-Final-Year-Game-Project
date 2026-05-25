using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroySelf : MonoBehaviour
{
    public GameObject self;
    //to distroy self
    public void distroy()
    {
        Destroy(self);
    }
}
