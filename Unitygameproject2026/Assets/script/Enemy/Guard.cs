using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            EnemyAddShield(20);
            //get power 3
        }
        else if(BattleManage.round % 3 == 1)
        {
            EnemyMakeDamage(10);
            EnemyMakeDamage(10);
            EnemyMakeDamage(10);
        }
        else
        {
            EnemyAddShield(40);
            //get power 5
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeDEFIntention("20");
            battleManage.changeBuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeATKIntention("10x3");
        }
        else
        {
            battleManage.changeDEFIntention("40");
            battleManage.changeBuffIntention();
        }
    }
    
}
