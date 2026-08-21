using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charge : MonoBehaviour
{
    public static int playerChargeNum = 0;
    public static int enemyChargeNum = 0;
    public GameObject playerCharge;
    public GameObject enemyCharge;
    public Text playerChargeTxt;
    public Text enemyChargeTxt;

    private void Update()
    {

        if (playerChargeNum <= 0)
        {
            playerCharge.SetActive(false);
        }
        else
        {
            playerCharge.SetActive(true);
        }

        if (enemyChargeNum == 0)
        {
            enemyCharge.SetActive(false);
        }
        else
        {
            enemyCharge.SetActive(true);
        }
        UpdateTxt();
    }

    public static void GivePlayerCharge(int num)
    {
        playerChargeNum += num;
    }

    public static void GiveEnemyCharge(int num)
    {
        enemyChargeNum += num;
    }

    public void UpdateTxt()
    {
        playerChargeTxt.text = playerChargeNum.ToString();
        enemyChargeTxt.text = enemyChargeNum.ToString();
    }

    public static void Reset()
    {
        playerChargeNum = 0;
        enemyChargeNum = 0;
    }
}


