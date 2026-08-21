using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCard : MonoBehaviour
{
    public static Queue<GameObject> CardActiveList = new Queue<GameObject>();
    void Start()
    {
        CardActiveList.Clear();
    }
    void Update()
    {
        if (BattleManage.turnState == 3)
        {
            while (CardActiveList.Count > 0)
            {
                CardEffect effect=CardActiveList.Dequeue().GetComponent<CardEffect>();
                effect.cardEffect();
            }
        }
    }
}
