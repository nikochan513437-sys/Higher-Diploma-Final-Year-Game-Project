using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(14);
    }
}
