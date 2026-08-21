using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corvette : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            EnemyMakeDamage(15);
        }
        else if(BattleManage.round % 3 == 1)
        {
            EnemyAddShield(7);
            Power.GiveEnemyPower(3);
        }
        else
        {
            EnemyMakeDamage(7);
            EnemyMakeDamage(7);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeATKIntention("15");
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeDEFIntention("7");
            battleManage.changeBuffIntention();
        }
        else
        {
            battleManage.changeATKIntention(""+7+"x2");
        }
    }
}
