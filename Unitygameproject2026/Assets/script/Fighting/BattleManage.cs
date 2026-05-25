using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleManage : MonoBehaviour
{
    //to manage battle
    public static bool inBattle = false;
    //save turn stage using int variable
    public static int turnState = 0;//turnState=1(turnStart),turnState=2(inturn),turnState=3(turnEnd),turnState=4(enemyStart),turnState=5(enemyEnd)
    //player health and max health
    public static int Health=0;
    public static int MaxHealth = 0;
    //player sheild
    public static int Sheild=0;
    //save player energy and max energe
    public static int MaxE1=0;
    public static int MaxE2 = 0;
    public static int MaxE3 = 0;
    public static int MaxE4 = 0;
    public static int E1=0;
    public static int E2=0;
    public static int E3=0;
    public static int E4=0;
    //battle round
    public static int round = 0;
    public static bool isboss;

    public static int atknum = 0;
    public static int defnum=0;

    public GameObject enenmy;
    public GameObject boss;
    public ModuleInventory Equip;
    public GameObject endGame;
    public GameObject winPanel;
    public GameObject deadPanel;
    public Text intentionTXT;
    public GameObject atkIntention;
    public GameObject defIntention;
    public static GameObject end;
    public static GameObject win;
    public static GameObject dead;
    public UpdateHealth updateHealth;
    public UpdateEnergy updateEnergy;
    public UpdateSheild updateSheild;
    public ModuleSlot slot1;
    public ModuleSlot slot2;
    public ModuleSlot slot3;
    public ModuleSlot slot4;
    public ModuleSlot slot5;
    public ModuleSlot slot6;
    void Start()
    {
        if (isboss)
        {
            //if battle is boss
            enenmy.SetActive(false);
            boss.SetActive(true);
        }
        else
        {
            //if battle not boss
            enenmy.SetActive(true);
            boss.SetActive(false);
        }
        //setup
        end = endGame;
        win = winPanel;
        dead = deadPanel ;
        win.SetActive(false);
        dead.SetActive(false);
        end.SetActive(false);
        inBattle = true;
        turnState = 0;
        round = 0;
        slot1.setSlot(Equip.moduleList[0]);
        slot2.setSlot(Equip.moduleList[1]);
        slot3.setSlot(Equip.moduleList[2]);
        slot4.setSlot(Equip.moduleList[3]);
        slot5.setSlot(Equip.moduleList[4]);
        slot6.setSlot(Equip.moduleList[5]);
        MaxHealth = calculateHealth();
        Health = MaxHealth;
        Sheild = 0;
        MaxE1 = 0;
        MaxE2 = 0; 
        MaxE3 = 0;
        MaxE4 = 0;
        calculateEnergy();
    }
    void Update()
    {
        //turn stage
        if (turnState == 0)
        {
            StartBattle();
        }
        if (turnState == 1)
        {
            TurnStart();
        }
        if (turnState == 2)
        {
        }
        if (turnState == 3)
        {
            TurnEnd();
        }
        if(turnState == 4)
        {
            if (isboss)
            {
                Enemy.BossAction();
            }
            else
            {
                Enemy.EnemyAction();
            }
            nextTurnState();
        }
        if( turnState == 5)
        {
            nextTurnState();
            round++;
            changeIntention();
        }
        updateHealth.UpdateH();
        updateSheild.UpdateS();
        updateEnergy.UpdateE();
    }
    public void StartBattle()
    {
        nextTurnState();
    }
    public void ButtonTurnEnd()
    {
        if (turnState == 2)
        {
            nextTurnState();
        }
    }
    public void TurnStart()
    {
        //show turn start
        getTurnStartEnergy();
        nextTurnState();
    }
    public void TurnEnd()
    {
        Debug.Log("Turn end");
        nextTurnState();
    }
    public void nextTurnState()
    {
        turnState++;
        turnState = turnState % 6;
        if( turnState == 0)
        {
            turnState++;
        }
        Debug.Log("Turn State=" + turnState);
    }
    public void calculateEnergy()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Equip.moduleList[i].moduleType.Equals("E"))
            {
                if (Equip.moduleList[i].moduleEnergyLevel == 1)
                {
                    MaxE1 += Equip.moduleList[i].moduleEnergyNumber;
                }
                if (Equip.moduleList[i].moduleEnergyLevel == 2)
                {
                    MaxE2 += Equip.moduleList[i].moduleEnergyNumber;
                }
                if (Equip.moduleList[i].moduleEnergyLevel == 3)
                {
                    MaxE3 += Equip.moduleList[i].moduleEnergyNumber;
                }
                if (Equip.moduleList[i].moduleEnergyLevel == 4)
                {
                    MaxE4 += Equip.moduleList[i].moduleEnergyNumber;
                }
            }
        }
        updateEnergy.UpdateE();
    }
    public int calculateHealth()
    {
        int sum = 0;
        for (int i = 0; i < 6; i++)
        {
            sum += Equip.moduleList[i].moduleArmor;
        }
        return sum;
    }
    public static void EndBattle()
    {
        inBattle = false;
        SceneManager.LoadScene("TutorialMap");
    }
    public static void EndGame()
    {
        end.SetActive(true);
    }

    public static void PlayerGetHeal(int health)
    {
        //use when heal
        Health += health;
    }
    public static void PlayerGetDamage(int damage)
    {
        if (EnemyAnim.instance != null && EnemyAnim.instance.gameObject.activeSelf)
            EnemyAnim.instance.PlayAtkAnim();
        if (BossAnim.instance != null && BossAnim.instance.gameObject.activeSelf)
            BossAnim.instance.PlayAtkAnim();

        //use when get damage
        int count = damage;
        if (Sheild > 0)
        {
            if (count < Sheild)
            {
                //damage<sheild
                Sheild -= count;
                count = 0;
            }
            else
            {
                //damage>=sheild
                count -= Sheild;
                Sheild = 0;
            }
        }
        AudioClipPlay.PlayClipGetHit();
        Health -= count;
        if (Health <= 0)
        {
            dead.SetActive(true);
            EndGame();
            ResetTutorial();
            //end game;
        }
    }
    public static void PlayerLostHealth(int lost)
    {
        //use when lost health
        Health -= lost;
        if (Health <= 0)
        {
            //end game;
        }
    }
    public static void PlayerCauseDamage(int damage)
    {
        //use when make damage
        int count = damage;
        if (Enemy.EnemySheild > 0)
        {
            if (count < Enemy.EnemySheild)
            {
                //damage<sheild
                Enemy.EnemySheild -= count;
                count = 0;
            }
            else
            {
                //damage>=sheild
                count -= Enemy.EnemySheild;
                Enemy.EnemySheild = 0;
            }
        }
        AudioClipPlay.PlayClipATK();
        Enemy.EnemyHealth -= count;
        if (Enemy.EnemyHealth <= 0)
        {
            if (isboss)
            {
                win.SetActive(true);
                EndGame();
                ResetTutorial();
            }
            else
            {
                EndBattle();
            }
            //end game;
        }
    }
    public static void PlayerGetSheild(int sheild)
    {
        //use when get sheild
        AudioClipPlay.PlayClipGetShield();
        Sheild += sheild;
    }
    public void getTurnStartEnergy()
    {
        //get energy when turn start
        E1 = 0;
        E2 = 0;
        E3 = 0;
        E4 = 0;
        getEnergy(1, MaxE1);
        getEnergy(2, MaxE2);
        getEnergy(3, MaxE3);
        getEnergy(4, MaxE4);
    }
    public static void getEnergy(int ELevel,int ENum)
    {
        if (ELevel == 1)
        {
            E1 += ENum;
        }
        if (ELevel == 2)
        {
            E2 += ENum;
        }
        if (ELevel == 3)
        {
            E3 += ENum;
        }
        if (ELevel == 4)
        {
            E4 += ENum;
        }
    }
    public static void lostEnergy(int ELevel,int ENum)
    {
        if (ELevel == 1&&ENum<=E1)
        {
            E1 -= ENum;
            Debug.Log("E lv" + ELevel + "=" + E1);
        }
        if (ELevel == 2 && ENum <= E2)
        {
            E2 -= ENum;
            Debug.Log("E lv"+ELevel+"=" + E2);
        }
        if (ELevel == 3 && ENum <= E3)
        {
            E3 -= ENum;
            Debug.Log("E lv" + ELevel + "=" + E3);
        }
        if (ELevel == 4 && ENum <= E4)
        {
            E4 -= ENum;
            Debug.Log("E lv" + ELevel + "=" + E4);
        }
    }

    public void changeIntention() {
        if (isboss)
        {
            if (round % 3 == 0 || round % 3 == 1)
            {
                atkIntention.SetActive(true);
                defIntention.SetActive(false);
                intentionTXT.text = atknum.ToString();
            }
            else
            {
                atkIntention.SetActive(false);
                defIntention.SetActive(true);
                intentionTXT.text = defnum.ToString();
            }
        }
        else
        {
            if (round % 2 == 0)
            {
                atkIntention.SetActive(true);
                defIntention.SetActive(false);
                intentionTXT.text = atknum.ToString();
            }
            else
            {
                atkIntention.SetActive(false);
                defIntention.SetActive(true);
                intentionTXT.text = defnum.ToString();
            }
        }
    }

    public static void ResetTutorial() {
        isboss = false;
        MapButtonEffect.enemyCanClick = true;
        MapButtonEffect.eventCanClick = false;
        MapButtonEffect.bossCanClick = false;
    }
}
