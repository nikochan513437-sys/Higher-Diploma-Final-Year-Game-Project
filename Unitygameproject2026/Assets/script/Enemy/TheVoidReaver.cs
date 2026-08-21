using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheVoidReaver : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 2 == 0)
        {
            EnemyMakeDamage(10);
            Void.GivePlayerVoid(2);
        }
        else
        {
            EnemyAddShield(10);
            Void.GivePlayerVoid(4);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 2 == 0)
        {
            battleManage.changeATKIntention("10");
            battleManage.changeDebuffIntention();
        }
        else
        {
            battleManage.changeDEFIntention("10");
            battleManage.changeDebuffIntention();
        }
    }
    
}
