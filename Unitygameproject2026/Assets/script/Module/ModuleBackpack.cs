using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBackpack : MonoBehaviour
{
    public ModuleInventory inventory;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public static ModuleInventory Inventory;
    public static ModuleSlot ModuleSlot1;
    public static ModuleSlot ModuleSlot2;
    public static ModuleSlot ModuleSlot3;
    public static ModuleSlot ModuleSlot4;
    public static ModuleSlot ModuleSlot5;
    public static ModuleSlot ModuleSlot6;
    public static ModuleSlot ModuleSlot7;
    public void Start()
    {
        //set data from static object
        Inventory = inventory;
        ModuleSlot1 = slot1.GetComponent<ModuleSlot>();
        ModuleSlot2 = slot2.GetComponent<ModuleSlot>();
        ModuleSlot3 = slot3.GetComponent<ModuleSlot>();
        ModuleSlot4 = slot4.GetComponent<ModuleSlot>();
        ModuleSlot5 = slot5.GetComponent<ModuleSlot>();
        ModuleSlot6 = slot6.GetComponent<ModuleSlot>();
        ModuleSlot7 = slot7.GetComponent<ModuleSlot>();
        UpdateBackpack();
    }
    public static void UpdateBackpack()
    {
        //update backpack(a scriptable object)
        ModuleSlot1.setSlot(Inventory.moduleList[0]);
        ModuleSlot2.setSlot(Inventory.moduleList[1]);
        ModuleSlot3.setSlot(Inventory.moduleList[2]);
        ModuleSlot4.setSlot(Inventory.moduleList[3]);
        ModuleSlot5.setSlot(Inventory.moduleList[4]);
        ModuleSlot6.setSlot(Inventory.moduleList[5]);
        ModuleSlot7.setSlot(Inventory.moduleList[6]);
        Debug.Log("inventory updated");
    }
}
