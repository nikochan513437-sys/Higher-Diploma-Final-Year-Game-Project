using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 2 == 0)
        {
            Emp.GivePlayerEmp(2);
        }
        else
        {
            EnemyMakeDamage(8);
            EnemyAddShield(8);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 2 == 0)
        {
            battleManage.changeDebuffIntention();
        }
        else
        {
            battleManage.changeATKIntention("8");
            battleManage.changeDEFIntention("8");
        }
    }
    
}
