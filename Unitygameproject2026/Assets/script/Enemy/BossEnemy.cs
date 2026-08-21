using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            battleManage.PlayerGetDamage(12);
        }
        else if(BattleManage.round % 3 == 1)
        {
            battleManage.PlayerGetDamage(21);        }
        else
        {
            EnemyAddShield(15);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeATKIntention("12");
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeATKIntention("21");
        }
        else
        {
            battleManage.changeDEFIntention("15");
        }
    }
}
