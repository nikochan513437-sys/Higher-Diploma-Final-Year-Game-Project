using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompoudAttack : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerCauseDamage(8);
        battleManage.PlayerGetSheild(8);
    }
}
