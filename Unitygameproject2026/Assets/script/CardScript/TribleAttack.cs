using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribleAttack : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(16*3);
    }
}
