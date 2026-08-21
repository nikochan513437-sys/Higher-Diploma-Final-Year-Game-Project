using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            Charge.GiveEnemyCharge(5);
        }
        else if(BattleManage.round % 3 == 1)
        {
            EnemyAddShield(20);
            Charge.GiveEnemyCharge(2);
        }
        else
        {
            EnemyMakeDamage(Charge.enemyChargeNum*10);
            Charge.enemyChargeNum = 0;
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeBuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeDEFIntention("20");
            battleManage.changeBuffIntention();
        }
        else
        {
            battleManage.changeATKIntention("" + (Charge.enemyChargeNum * 10));
        }
    }
}
