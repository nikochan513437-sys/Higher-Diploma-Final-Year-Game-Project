using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnstableBlast : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(20);
        Overheat.GivePlayerOverheat(4);
    }
}
