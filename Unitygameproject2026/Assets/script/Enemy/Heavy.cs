using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            Overheat.GiveEnemyOverheat(15);
            EnemyMakeDamage(20);
        }
        else if (BattleManage.round % 3 == 1)
        {
            EnemyAddShield(40);
            Overheat.GivePlayerOverheat(Overheat.enemyOverheatNum);
            Overheat.enemyOverheatNum = 0;
        }
        else
        {
            if (Overheat.playerOverheatNum > 0)
            {
                EnemyMakeDamage(45);
            }
            else
            {
                EnemyMakeDamage(30);
            }
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeATKIntention("20");
            battleManage.changeBuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeDEFIntention("40");
            battleManage.changeDebuffIntention();
        }
        else
        {
            if (Overheat.playerOverheatNum > 0)
            {
                battleManage.changeATKIntention("45");
            }
            else
            {
                battleManage.changeATKIntention("30");
            }

        }
    }

}
