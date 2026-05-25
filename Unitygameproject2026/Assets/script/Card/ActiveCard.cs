using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour
{
    public static Queue<int> CardActiveList = new Queue<int>();
    void Start()
    {
        CardActiveList.Clear();
    }
    void Update()
    {
        if (BattleManage.turnState == 3)
        {
            while (CardActiveList.Count > 0)
            {
                int cardnum=CardActiveList.Dequeue();
                if (cardnum == 0)
                {
                    Attack(14);
                    SheetAtkAnim.instance.PlaySheetAttackAnim();
                }
                if (cardnum == 1)
                {
                    Defence(11);
                }
            }
        }
    }
    public void Attack(int damage)
    {
        BattleManage.PlayerCauseDamage(damage);
    }
    public void Defence(int sheild)
    {
        BattleManage.PlayerGetSheild(sheild);
    }
}
