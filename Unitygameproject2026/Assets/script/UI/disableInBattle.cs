using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class disableInBattle : MonoBehaviour
{
    public Button button;
    void Update()
    {
        if (BattleManage.inBattle)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
