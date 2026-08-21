using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnShow : MonoBehaviour
{
    private TextMeshProUGUI roundText;
    private void Awake()
    {
       roundText = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        roundText.text = BattleManage.round.ToString();
    }
}
