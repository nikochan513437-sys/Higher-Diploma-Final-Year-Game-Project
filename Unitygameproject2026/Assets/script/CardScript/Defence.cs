using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : CardEffect
{
    public override void cardEffect()
    {
        battleManage.PlayerGetSheild(11);
    }
}
