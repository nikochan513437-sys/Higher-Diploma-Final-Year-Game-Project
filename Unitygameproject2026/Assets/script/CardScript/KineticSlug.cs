using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticSlug: CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(10 + (Charge.playerChargeNum*3));
        Charge.GivePlayerCharge(1);
    }
}
