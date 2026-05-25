using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanage : MonoBehaviour
{
    public static bool spawn=false;
    private void Awake()
    {
        if (spawn)
        {
            Destroy(gameObject);
        }
        else
        {
            spawn = true;
        }
    }
}
