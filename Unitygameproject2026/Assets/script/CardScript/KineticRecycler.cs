using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticRecycler : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerGetSheild(16);
        if (BattleManage.Sheild > 0) {
            Power.GivePlayerPower(1);
        }
    }
}
