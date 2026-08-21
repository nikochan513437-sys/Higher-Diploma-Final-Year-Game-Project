using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAegis: CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerGetSheild(14);
        Charge.GivePlayerCharge(1);
    }
}
