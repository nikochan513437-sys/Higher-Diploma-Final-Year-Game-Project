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
    public static int turnState = 0;
    //turnState=1(turnStart),turnState=2(inturn),turnState=3(turnEnd),turnState=4(enemyStart),turnState=5(enemyEnd)
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

    public GameObject dodge;
    public static GameObject dodge1;
    public static bool resetState;
    public static bool isDodge;

    public Canvas canvas;
    public GameObject MainCam;
    public ModuleInventory Equip;
    public GameObject endGame;
    public GameObject winPanel;
    public GameObject deadPanel;
    public GameObject skipButton;
    public GameObject ATKIntention;
    public GameObject ATKIntentionNum;
    public GameObject DEFIntention;
    public GameObject DEFIntentionNum;
    public GameObject STUNIntention;
    public GameObject BUFFIntention;
    public GameObject DEBUFFIntention;
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
    public GameEnemy enemy;

    //public GameObject resultPanel;

    public List<CardEffect> cardEffects = new List<CardEffect>();
    void Start()
    {
        MainCam=GameObject.Find("Main Camera-GameMap");
        //resultPanel = GameObject.Find("ResultPanel");
        MainCam.SetActive(false);
        if (DeveloperMode.isDeveloper)
            skipButton.SetActive(DeveloperMode.isDeveloper);
        //setup
        end = endGame;
        win = winPanel;
        dead = deadPanel;
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
        GenerateDodgeUI();
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
            enemy.EnemyAction();
            nextTurnState();
        }
        if(turnState == 5)
        {
            nextTurnState();
            round++;
        }
        updateHealth.UpdateH();
        updateSheild.UpdateS();
        updateEnergy.UpdateE();
    }
    public void StartBattle()
    {
        enemy = Object.FindAnyObjectByType<GameEnemy>();
        nextTurnState();
    }
    public void ButtonTurnEnd()
    {
        Debug.Log("Card List length:"+cardEffects.Count);
        for (int i = 0 ; i < cardEffects.Count; i++) {
            cardEffects[i].cardEffect();
        }
        cardEffects.Clear();
        if (turnState == 2)
        {
            nextTurnState();
        }
    }
    public void TurnStart()
    {
        //show turn start
        enemy.EnemyActionShow();
        getTurnStartEnergy();
        nextTurnState();
        //ModuleUseEquip.useDodge = 0;
    }
    public void TurnEnd()
    {
        Debug.Log("Turn end");
        StatusSettlement();
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

    public void StatusSettlement() {
        if (Overheat.playerOverheatNum > 0)
        {
            PlayerLostHealth(Overheat.getPlayerOverheatDmg());
            Overheat.playerOverheatNum /= 2;
        }
        if (Overheat.enemyOverheatNum > 0)
        {
            enemy.EnemyLostHealth(Overheat.getEnemyOverheatDmg());
            Overheat.enemyOverheatNum /= 2;
        }
        if (Emp.playerEmpNum > 0) {
            Emp.playerEmpNum--;
        }
        if (Emp.enemyEmpNum > 0)
        {
            Emp.enemyEmpNum--;
        }
    }

    public void EndBattle()
    {
        Debug.Log("Battle End");
        int coin = 100;
        float healthPercentage = (float)Health / MaxHealth;
        int baseCoin = Mathf.RoundToInt(coin * healthPercentage);
        float bonusPercentage;
        if (round > 20) 
        {
            bonusPercentage = 0f;
        }
        else 
        {
            bonusPercentage = 1 - (Mathf.Pow((float)round - 1, 2) / 400);
        }
        int bounsCoin = Mathf.RoundToInt(coin * bonusPercentage);
        Debug.Log(baseCoin +" " + bounsCoin);
        inBattle = false;
        MainCam.SetActive(true);
        Overheat.Reset();
        Charge.Reset();
        Emp.Reset();
        Power.Reset();
        Void.Reset();
        SceneManager.UnloadSceneAsync("Fighting");
        GameManage.ResultPanel(baseCoin, bounsCoin);
    }
    public static void EndGame()
    {
        end.SetActive(true);
        win.SetActive(true);
    }

    public void PlayerGetHeal(int health)
    {
        //use when heal
        Health += health;
    }
    public void PlayerGetDamage(int damage)
    {
        /*
        if (EnemyAnim.instance != null && EnemyAnim.instance.gameObject.activeSelf)
            EnemyAnim.instance.PlayAtkAnim();
        if (BossAnim.instance != null && BossAnim.instance.gameObject.activeSelf)
            BossAnim.instance.PlayAtkAnim();
        */

       

        if (isDodge)
        {
            Debug.Log("dodge");
            OnDodge.onDodge();
            isDodge = false;
            return;
        }

        //use when get damage
        int count = damage;

        if (Emp.playerEmpNum > 0)
        {
            count = (int)(count * 0.75);
        }

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
    public void PlayerLostHealth(int lost)
    {
        //use when lost health
        Health -= lost;
        if (Health <= 0)
        {
            dead.SetActive(true);
            EndGame();
            ResetTutorial();
            //end game;
        }
    }
    public void PlayerCauseDamage(int damage)
    {
        int dmg = damage;
        dmg += Power.playerPowerNum;
        dmg += Void.enemyVoidNum;

        if (Emp.playerEmpNum > 0)
        {
            dmg = (int)(dmg * 0.75);
        }
        enemy.EnemyTakeDamage(dmg);
        AudioClipPlay.PlayClipATK();
    }
    public void PlayerGetSheild(int sheild)
    {
        //use when get sheild
        Sheild += sheild;
        AudioClipPlay.PlayClipGetShield();
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

    public void resetIntention()
    {
        ATKIntention.SetActive(false);
        ATKIntentionNum.SetActive(false);
        DEFIntention.SetActive(false);
        DEFIntentionNum.SetActive(false);
        STUNIntention.SetActive(false);
        BUFFIntention.SetActive(false);
        DEBUFFIntention.SetActive(false);
    }
    public void changeATKIntention(string txt)
    {
        ATKIntention.SetActive(true);
        ATKIntentionNum.SetActive(true);
        ATKIntentionNum.GetComponent<Text>().text = txt;
        //atkIntention.SetActive(true);
        //defIntention.SetActive(false);
        //intentionNum.SetActive(true);
        //intentionText.text = num.ToString();
    }
    public void changeDEFIntention(string txt)
    {
        DEFIntention.SetActive(true);
        DEFIntentionNum.SetActive(true);
        DEFIntentionNum.GetComponent<Text>().text = txt;
        //atkIntention.SetActive(false);
        //defIntention.SetActive(true);
        //intentionNum.SetActive(true);
        //intentionText.text = num.ToString();
    }
    public void changeBuffIntention()
    {
        BUFFIntention.SetActive(true);
    }
    public void changeDebuffIntention()
    {
        DEBUFFIntention.SetActive(true);
    }
    public void changeStunIntention()
    {
        STUNIntention.SetActive(true);
    }

    public void GenerateDodgeUI() {
        if (SetEquipment.isEquipped)
        {
            GameObject dodgeObj = Instantiate(dodge, canvas.transform);
            RectTransform dodgeTrans = dodgeObj.GetComponent<RectTransform>();
            dodgeTrans.anchoredPosition = new Vector2(-800, 200);
            dodge1 = dodgeObj;
        }
    }

    public static void ResetTutorial() {
        MapButtonEffect.enemyCanClick = true;
        MapButtonEffect.eventCanClick = false;
        MapButtonEffect.bossCanClick = false;
    }

    public void SkipBattle() {
        enemy.EnemyLostHealth(enemy.maxhealth);
    }

    public void RegisterCardEffect(CardEffect effect) { 
        cardEffects.Add(effect);
    }
}
