using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    private Animator anim;

    public static BossAnim instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
            Destroy(gameObject);
    }

    public void PlayAtkAnim()
    {
        Debug.Log("play boss atk anim");
        anim.SetTrigger("attack");
    }
}
