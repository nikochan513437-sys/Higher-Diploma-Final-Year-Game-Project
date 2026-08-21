using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperVelocityRound : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(12);
        for (int i = 0; i < 3; i++) {
            if (Charge.playerChargeNum > 0)
            {
                Overheat.GiveEnemyOverheat(6);
                Charge.playerChargeNum--;
            }
            else {
                break;
            }
        }
    }
}
