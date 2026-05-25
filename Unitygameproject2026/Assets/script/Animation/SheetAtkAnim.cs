using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetAtkAnim : MonoBehaviour
{
    private Animator anim;

    public static SheetAtkAnim instance;

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

    public void PlaySheetAttackAnim()
    {
        Debug.Log("play atk anim");
        anim.SetTrigger("attack");
    }

    public void PlayEnemyHurtAnim()
    {
       Debug.Log("play sheetAtk anim");
        EnemyAnim.instance.PlayHurtAnim();
    }
}
