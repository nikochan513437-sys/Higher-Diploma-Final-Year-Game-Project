using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameEnemy : MonoBehaviour
{
    public string enemyName;
    public string enemyType;
    public int maxhealth;
    public int health;
    public int shield;
    protected BattleManage battleManage;
    protected Slider EnemyHealthSlider;
    protected Text HealthText;
    protected Text SheildText;
    public void Awake()
    {
        battleManage = GameObject.Find("BattleManage").GetComponent<BattleManage>();
        EnemyHealthSlider = GameObject.Find("HealthBarSlider-Enemy").GetComponent<Slider>();
        HealthText= GameObject.Find("HealthText-Enemy").GetComponent<Text>();
        SheildText = GameObject.Find("SheildTxt-Enemy").GetComponent<Text>();
        EnemySpawn();
    }
    public void Update()
    {
        UpdateEnemyHealth();
        UpdateEnemyShield();
        //Debug.Log("enemy health=" + health);
    }
    public virtual void EnemyActionShow()
    {

    }
    public virtual void EnemyAction()
    {

    }

    public virtual void EnemyMakeDamage(int damageNumber)
    {
        damageNumber+=Power.enemyPowerNum;
        damageNumber+=Void.playerVoidNum;
        if (Emp.playerEmpNum > 0)
        {
            damageNumber = (int)(damageNumber * 0.75);
        }
        battleManage.PlayerGetDamage(damageNumber);
    }
    public virtual void EnemyTakeDamage(int damageNumber)
    {
        if (Emp.playerEmpNum > 0)
        {
            damageNumber = (int)(damageNumber * 1.25);
        }
        int count = damageNumber;
        if (shield > 0)
        {
            if (count < shield)
            {
                //damage<sheild
                shield -= count;
                count = 0;
            }
            else
            {
                //damage>=shield
                count -= shield;
                shield = 0;
            }
        }
        health -= count;
        DetectEnemyIsDie();
    }
    public virtual void EnemyLostHealth(int damageNumber)
    {
        health -= damageNumber;
        DetectEnemyIsDie();
    }
    public virtual void EnemyAddHealth(int num)
    {
        health += num;
    }
    public virtual void EnemyAddShield(int num)
    {
        shield += num;
    }
    public virtual void EnemySpawn()
    {
        health=maxhealth;
        shield = 0;
    }
    public virtual void DetectEnemyIsDie()
    {
        if (health <= 0)
        {
            EnemyDie();
        }
    }
    public virtual void EnemyDie()
    {
        if (enemyType.Equals("Boss"))
        {
            BattleManage.EndGame();
        }
        else
        {
            battleManage.EndBattle();
        }
    }
    public void UpdateEnemyHealth()
    {
        EnemyHealthSlider.maxValue = maxhealth;
        EnemyHealthSlider.value = health;
        HealthText.text = health + "/" + maxhealth;
    }
    public void UpdateEnemyShield()
    {
        SheildText.text = shield.ToString();
    }

}
