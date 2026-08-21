using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DischargeBolt: CardEffect
{
    public override void cardEffect()
    {
        if (Charge.playerChargeNum >= 1)
        {
            battleManage.PlayerCauseDamage(12 + (Charge.playerChargeNum * 8));
            Charge.playerChargeNum--;
        }
        else {
            battleManage.PlayerCauseDamage(12);
        }
    }
}
