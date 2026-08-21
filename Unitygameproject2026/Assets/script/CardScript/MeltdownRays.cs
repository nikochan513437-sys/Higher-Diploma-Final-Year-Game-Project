using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltdownRays: CardEffect
{
    public override void cardEffect()
    {
        Overheat.GiveEnemyOverheat(20);
    }
}
