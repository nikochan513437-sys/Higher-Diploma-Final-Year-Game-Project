using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModuleManage : MonoBehaviour
{
    public ModuleInventory inventory;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public static ModuleInventory Inventory;
    public static ModuleSlot ModuleSlot1;
    public static ModuleSlot ModuleSlot2;
    public static ModuleSlot ModuleSlot3;
    public static ModuleSlot ModuleSlot4;
    public static ModuleSlot ModuleSlot5;
    public static ModuleSlot ModuleSlot6;
    public GameObject health;
    public static Text healthtxt;
    public void Start()
    {
        //set data of static variable at start
        Inventory = inventory;
        ModuleSlot1=slot1.GetComponent<ModuleSlot>();
        ModuleSlot2=slot2.GetComponent<ModuleSlot>();
        ModuleSlot3=slot3.GetComponent<ModuleSlot>();
        ModuleSlot4=slot4.GetComponent<ModuleSlot>();
        ModuleSlot5=slot5.GetComponent<ModuleSlot>();
        ModuleSlot6=slot6.GetComponent<ModuleSlot>();
        UpdateInventory();
        healthtxt = health.GetComponent<Text>();
        updateHealth();
    }
    public static int calculateHealth()
    {
        int sum = 0;
        sum = ModuleSlot1.slot.moduleArmor+ ModuleSlot2.slot.moduleArmor+ ModuleSlot3.slot.moduleArmor+ ModuleSlot4.slot.moduleArmor+ ModuleSlot5.slot.moduleArmor+ ModuleSlot6.slot.moduleArmor;
        return sum;
    }
    public static void updateHealth()
    {
        //update the max health when equip module get change
        healthtxt.text = calculateHealth().ToString();
        Debug.Log("health updated ,health "+calculateHealth());
    }
    public static void UpdateInventory()
    {
        //update inventory (a scriptable object)
        ModuleSlot1.setSlot(Inventory.moduleList[0]);
        ModuleSlot2.setSlot(Inventory.moduleList[1]);
        ModuleSlot3.setSlot(Inventory.moduleList[2]);
        ModuleSlot4.setSlot(Inventory.moduleList[3]);
        ModuleSlot5.setSlot(Inventory.moduleList[4]);
        ModuleSlot6.setSlot(Inventory.moduleList[5]);
        Debug.Log("equip updated");
    }
}
