using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverchargedInsulation : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerGetSheild(25);
        Overheat.GivePlayerOverheat(5);
    }
}
