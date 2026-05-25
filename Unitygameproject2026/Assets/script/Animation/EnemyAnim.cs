using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Animator anim;

    public static EnemyAnim instance;

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

    public void PlayHurtAnim()
    {
        Debug.Log("play hurt anim");
        anim.SetTrigger("getHit");
    }

    public void PlayAtkAnim()
    {
        Debug.Log("play atk anim");
        anim.SetTrigger("attack");
    }
}
