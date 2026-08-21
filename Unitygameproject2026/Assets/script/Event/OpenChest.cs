using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenChest : MonoBehaviour
{
    private Animator anim;
    public GameObject chestOpen;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        Debug.Log("open chest");
        anim.SetTrigger("open");
    }

    public void ChestOpen() 
    {
        gameObject.SetActive(false);
        chestOpen.SetActive(true);
    }
}
