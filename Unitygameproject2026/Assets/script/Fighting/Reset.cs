using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public ModuleInventory equip;
    public ModuleInventory inventory;
    public Module attack;
    public Module defence;
    public Module energy;
    public Module armor;
    public Module nomodule;
    public static Module Attack;
    public static Module Defence;
    public static Module Energy;
    public static Module Armor;
    public static Module Nomodule;
    public static ModuleInventory Equip;
    public static ModuleInventory Inventory;
    public void Start()
    {
        Equip = equip;
        Inventory = inventory;
        Attack = attack;
        Defence = defence;
        Energy = energy;
        Armor = armor;
        Nomodule = nomodule;
    }
    public static void reset()
    {
        SetEquipment.SetEquip(false);
        BattleManage.inBattle = false;
        Coin.ResetCoin();
        Equip.moduleList[0] = Attack;
        Equip.moduleList[1] = Energy;
        Equip.moduleList[2] = Nomodule;
        Equip.moduleList[3] = Nomodule;
        Equip.moduleList[4] = Defence;
        Equip.moduleList[5] = Armor;
        for (int i = 0; i < Inventory.moduleList.Count; i++)
        {
            Inventory.moduleList[i]=Nomodule;
        }
    }
}
