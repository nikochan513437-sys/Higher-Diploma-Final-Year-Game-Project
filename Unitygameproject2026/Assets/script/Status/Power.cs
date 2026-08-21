using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public static int playerPowerNum = 0;
    public static int enemyPowerNum = 0;
    public GameObject playerPower;
    public GameObject enemyPower;
    public Text playerPowerTxt;
    public Text enemyPowerTxt;

    private void Update()
    {

        if (playerPowerNum <= 0)
        {
            playerPower.SetActive(false);
        }
        else
        {
            playerPower.SetActive(true);
        }

        if (enemyPowerNum == 0)
        {
            enemyPower.SetActive(false);
        }
        else
        {
            enemyPower.SetActive(true);
        }
        UpdateTxt();
    }

    public static void GivePlayerPower(int num)
    {
        playerPowerNum += num;
    }

    public static void GiveEnemyPower(int num)
    {
        enemyPowerNum += num;
    }

    public void UpdateTxt()
    {
        playerPowerTxt.text = playerPowerNum.ToString();
        enemyPowerTxt.text = enemyPowerNum.ToString();
    }

    public static void Reset()
    {
        playerPowerNum = 0;
        enemyPowerNum = 0;
    }
}


