using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLEEKER : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            EnemyMakeDamage(18);
            BattleManage.MaxE1 -= 1;
        }
        else if(BattleManage.round % 3 == 1)
        {
            Charge.GiveEnemyCharge(5);
            BattleManage.MaxE1 += 1;
        }
        else
        {
            EnemyMakeDamage(Charge.enemyChargeNum * 5);
            Charge.enemyChargeNum = 0;
            Emp.GivePlayerEmp(2);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeATKIntention("18");
            battleManage.changeDebuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeBuffIntention();
        }
        else
        {
            battleManage.changeATKIntention("" + Charge.enemyChargeNum * 5);
            battleManage.changeDebuffIntention();
        }
    }
    
}
