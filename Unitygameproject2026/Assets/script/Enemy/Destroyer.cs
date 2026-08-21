using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            Overheat.GivePlayerOverheat(10);
            Overheat.GiveEnemyOverheat(5);
        }
        else if(BattleManage.round % 3 == 1)
        {
            EnemyMakeDamage(39);
            Overheat.GiveEnemyOverheat(5);
        }
        else
        {
            EnemyAddShield(30);
            Overheat.GiveEnemyOverheat(5);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeBuffIntention();
            battleManage.changeDebuffIntention();
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeATKIntention("39");
            battleManage.changeDebuffIntention();
        }
        else
        {
            battleManage.changeDEFIntention("30");
            battleManage.changeDebuffIntention();
        }
    }
}
