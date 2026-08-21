using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 2 == 0)
        {
            EnemyMakeDamage(10);
        }
        else
        {
            EnemyAddShield(8);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 2 == 0)
        {
            battleManage.changeATKIntention("10");
        }
        else
        {
            battleManage.changeDEFIntention("8");
        }
    }
    
}
