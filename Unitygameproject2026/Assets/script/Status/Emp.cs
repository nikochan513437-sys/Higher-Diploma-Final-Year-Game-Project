using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emp : MonoBehaviour
{
    public static int playerEmpNum = 0;
    public static int enemyEmpNum = 0;
    public GameObject playerEmp;
    public GameObject enemyEmp;
    public Text playerEmpTxt;
    public Text enemyEmpTxt; 

    private void Update()
    {

        if (playerEmpNum <= 0)
        {
            playerEmp.SetActive(false);
        }
        else
        {
            playerEmp.SetActive(true);
        }

        if (enemyEmpNum == 0)
        {
            enemyEmp.SetActive(false);
        }
        else
        {
            enemyEmp.SetActive(true);
        }
        UpdateTxt();
    }

    public static void GivePlayerEmp(int num)
    {
        playerEmpNum += num;
    }

    public static void GiveEnemyEmp(int num)
    {
        enemyEmpNum += num;
    }

    public void UpdateTxt()
    {
        playerEmpTxt.text = playerEmpNum.ToString();
        enemyEmpTxt.text = enemyEmpNum.ToString();
    }

    public static void Reset()
    {
        playerEmpNum = 0;
        enemyEmpNum = 0;
    }
}


