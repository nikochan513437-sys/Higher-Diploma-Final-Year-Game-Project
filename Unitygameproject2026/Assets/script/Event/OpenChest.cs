using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenChest : MonoBehaviour
{
    private Animator anim;
    public GameObject chestOpen;
    public GameObject equipment;

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
        equipment.SetActive(true);
        equipment.transform.DOMove(new Vector3(0.2f, 1.68f, 0),1f);
    }
}
