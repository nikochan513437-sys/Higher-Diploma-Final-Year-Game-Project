using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleAttack : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(11*2);
    }
}
