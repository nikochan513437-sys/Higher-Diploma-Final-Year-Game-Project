using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas1 : MonoBehaviour
{
    public static Canvas1 instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
}
