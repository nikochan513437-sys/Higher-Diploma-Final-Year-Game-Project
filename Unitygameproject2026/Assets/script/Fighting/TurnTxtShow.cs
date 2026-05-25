using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TurnTxtShow : MonoBehaviour
{
    public GameObject TurnStart;
    public GameObject TurnEnd;
    public float showTime = 2f;
    void Update()
    {
        if (BattleManage.turnState == 1)
        {
            Debug.Log("show turn start");
            TurnStart.SetActive(true);
            StartCoroutine(DelayedAction());
            TurnStart.SetActive(false);
        }
        if (BattleManage.turnState == 3)
        {
            Debug.Log("show turn end");
            TurnEnd.SetActive(true);
            StartCoroutine(DelayedAction());
            TurnEnd.SetActive(false);
        }
    }
    IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(showTime); // Game keeps running
    }
}
