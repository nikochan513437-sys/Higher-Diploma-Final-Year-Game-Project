using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escort : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            EnemyAddShield(50);
            Emp.GivePlayerEmp(1);
        }
        else if(BattleManage.round % 3 == 1)
        {
            if (shield > 0)
            {
                EnemyMakeDamage(37);
            }
            else
            {
                EnemyMakeDamage(12);
            }
        }
        else
        {
            EnemyMakeDamage(shield);
            shield = 0;
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeDEFIntention("50");
            battleManage.changeDebuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            if (shield > 0)
            {
                battleManage.changeATKIntention("37");
            }
            else
            {
                battleManage.changeATKIntention("12");
            }
        }
        else
        {
            battleManage.changeATKIntention(""+shield);
        }
    }
}
