using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModuleGiveCard : MonoBehaviour, IPointerClickHandler
{
    public ModuleSlot slot;
    public int EL;
    public int EN;
    public int getcard = 0;
    //public BattleManage battleManage;
    public void Start()
    {
        //set static variable at start
        EL = slot.slot.moduleEnergyLevel;
        EN = slot.slot.moduleEnergyNumber;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //when right click on the module,lost energy and get card
        EL = slot.slot.moduleEnergyLevel;
        EN = slot.slot.moduleEnergyNumber;
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (slot.slot.willGiveCard)
            {
                if (EL == 1 &&BattleManage.E1>=EN)
                {
                    getcard = 1;
                }
                else if (EL == 2 && BattleManage.E2 >= EN)
                {
                    getcard = 1;
                }
                else if(EL == 3 && BattleManage.E3 >= EN)
                {
                    getcard = 1;
                }
                else if(EN == 4 && BattleManage.E3 >= EN)
                {
                    getcard = 1;
                }
                if (getcard == 1)
                {
                    CardSystem.instance.SpawnCardByIndex(slot.slot.giveCardNo);
                    CardSystem.instance.DrawCard();
                    Debug.Log("lostE,getcard");
                    BattleManage.lostEnergy(EL, EN);
                    getcard = 0;
                }
            }
        }
    }
}
