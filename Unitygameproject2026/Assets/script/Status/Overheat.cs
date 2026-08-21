using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overheat : MonoBehaviour
{
    public static int playerOverheatNum = 0;
    public static int enemyOverheatNum = 0;
    public GameObject playerOverheat;
    public GameObject enemyOverheat;
    public Text playerOverheatTxt;
    public Text enemyOverheatTxt;

    private void Update()
    {

        if (playerOverheatNum == 0)
        {
            playerOverheat.SetActive(false);
        }
        else {
            playerOverheat.SetActive(true);
        }

        if (enemyOverheatNum == 0)
        {
            enemyOverheat.SetActive(false);
        }
        else {
            enemyOverheat.SetActive(true);
        }
        UpdateTxt();
    }
    public static void GivePlayerOverheat(int num) {
        playerOverheatNum += num;
    }

    public static void GiveEnemyOverheat(int num)
    {
        enemyOverheatNum += num;
    }

    public static int getPlayerOverheatDmg() {
        return playerOverheatNum;
    }

    public static int getEnemyOverheatDmg()
    {
        return enemyOverheatNum;
    }

    public void UpdateTxt() { 
        playerOverheatTxt.text = playerOverheatNum.ToString();
        enemyOverheatTxt.text = enemyOverheatNum.ToString();
    }

    public static void Reset() {
        playerOverheatNum = 0;
        enemyOverheatNum = 0;
    }
}
