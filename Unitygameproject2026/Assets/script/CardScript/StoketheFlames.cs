using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkoketheFlames : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(5);
        battleManage.PlayerCauseDamage(Overheat.enemyOverheatNum);
    }
}
