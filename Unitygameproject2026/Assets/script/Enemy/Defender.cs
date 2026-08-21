using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : GameEnemy
{
    public override void EnemyAction()
    {
        if (BattleManage.round % 3 == 0)
        {
            EnemyAddShield(100);
        }
        else if(BattleManage.round % 3 == 1)
        {
            
        }
        else
        {
            EnemyMakeDamage(shield);
        }
    }
    public override void EnemyActionShow()
    {
        battleManage.resetIntention();
        if (BattleManage.round % 3 == 0)
        {
            battleManage.changeDEFIntention("100");
        }
        else if (BattleManage.round % 3 == 1)
        {
            battleManage.changeStunIntention();
        }
        else
        {
            battleManage.changeATKIntention("" + shield);
        }
    }
    
}
