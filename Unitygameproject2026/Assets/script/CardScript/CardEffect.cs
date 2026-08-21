using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public BattleManage battleManage;
    public void Start()
    {
        battleManage = FindObjectOfType<BattleManage>();
    }
    public virtual void cardEffect() { }
}
