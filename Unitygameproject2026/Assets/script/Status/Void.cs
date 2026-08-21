using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Void : MonoBehaviour
{
    public static int playerVoidNum = 0;
    public static int enemyVoidNum = 0;
    public GameObject playerVoid;
    public GameObject enemyVoid;
    public Text playerVoidTxt;
    public Text enemyVoidTxt;

    private void Update()
    {

        if (playerVoidNum <= 0)
        {
            playerVoid.SetActive(false);
        }
        else
        {
            playerVoid.SetActive(true);
        }

        if (enemyVoidNum == 0)
        {
            enemyVoid.SetActive(false);
        }
        else
        {
            enemyVoid.SetActive(true);
        }
        UpdateTxt();
    }

    public static void GivePlayerVoid(int num)
    {
        playerVoidNum += num;
    }

    public static void GiveEnemyVoid(int num)
    {
        enemyVoidNum += num;
    }

    public void UpdateTxt()
    {
        playerVoidTxt.text = playerVoidNum.ToString();
        enemyVoidTxt.text = enemyVoidNum.ToString();
    }

    public static void Reset()
    {
        playerVoidNum = 0;
        enemyVoidNum = 0;
    }
}


