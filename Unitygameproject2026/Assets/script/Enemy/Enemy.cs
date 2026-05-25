using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int EnemyH=0;
    public static int EnemyMaxHealth=0;
    public static int EnemyHealth=0;
    public static int EnemySheild=0;
    public static int Enemymove = 0;
    public Slider EnemyHealthSlider;
    public Text HealthText;
    public Text SheildText;
    public GameObject enemy;
    public void Awake()
    {
        if (BattleManage.isboss)
        {
            BattleManage.atknum = 21;
            BattleManage.defnum = 12;
            EnemyMaxHealth = 150;
        }
        else
        {
            BattleManage.atknum = 10;
            BattleManage.defnum = 8;
            EnemyMaxHealth = 120;
        }
        //EnemyMaxHealth = EnemyH;
        EnemyHealth = EnemyMaxHealth;
        Enemymove = 0;
    }
    public void Update()
    {
        Debug.Log(BattleManage.isboss);
        UpdateEnemyHealth();
        UpdateEnemyShield();
    }
    public void UpdateEnemyHealth()
    {
        EnemyHealthSlider.maxValue = EnemyMaxHealth;
        EnemyHealthSlider.value = EnemyHealth;
        HealthText.text = EnemyHealth + "/" + EnemyMaxHealth;
    }
    public void UpdateEnemyShield()
    {
        SheildText.text = EnemySheild.ToString();
    }
    public static void EnemyAction()
    {
        if (Enemymove % 2 == 0)
        {
            BattleManage.PlayerGetDamage(10);
        }
        else
        {
            AudioClipPlay.PlayClipGetShield();
            EnemySheild += 8;
        }
        Enemymove++;
    }
    public static void BossAction()
    {
        if (Enemymove % 3 == 0||Enemymove%3==1)
        {
            BattleManage.PlayerGetDamage(21);
        }
        else
        {
            EnemySheild += 12;
        }
        Enemymove++;
    }
}
