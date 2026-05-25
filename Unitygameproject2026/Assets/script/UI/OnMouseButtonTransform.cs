using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseButtonTransform : MonoBehaviour
{
    //public GameObject canvas;
    Vector3 localScale;
    float scaleX;
    float scaleY;
    float scaleZ;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            transform.localScale = new Vector3(scaleX + 0.05f, scaleY + 0.05f, scaleZ);
        }
    }
    void OnMouseExit()
    {
         transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}
