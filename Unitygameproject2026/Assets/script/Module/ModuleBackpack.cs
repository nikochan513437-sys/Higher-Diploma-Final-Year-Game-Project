using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModuleBackpack : MonoBehaviour
{
    public ModuleInventory backpack;
    public ModuleSlot[] backpackSlots = new ModuleSlot[21];

    public static ModuleInventory Backpack;
    public static ModuleSlot[] BackpackSlots;

    public void Start()
    {
        Backpack = backpack;
        BackpackSlots = new ModuleSlot[backpackSlots.Length];
        BackpackSlots = backpackSlots;
        UpdateBackpack();
    }
    
    public static void UpdateBackpack()
    {
        for (int i = 0; i < BackpackSlots.Length; i++)
        {
            BackpackSlots[i].setSlot(Backpack.moduleList[i]);
        }
        Debug.Log("Inventory updated");
    }
}
    /*
    public ModuleInventory inventory;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public GameObject slot8;
    public GameObject slot9;
    public GameObject slot10;
    public GameObject slot11;
    public GameObject slot12;
    public GameObject slot13;
    public GameObject slot14;
    public GameObject slot15;
    public GameObject slot16;
    public GameObject slot17;
    public GameObject slot18;
    public GameObject slot19;
    public GameObject slot20;
    public GameObject slot21;
    public static ModuleInventory Inventory;
    public static ModuleSlot ModuleSlot1;
    public static ModuleSlot ModuleSlot2;
    public static ModuleSlot ModuleSlot3;
    public static ModuleSlot ModuleSlot4;
    public static ModuleSlot ModuleSlot5;
    public static ModuleSlot ModuleSlot6;
    public static ModuleSlot ModuleSlot7;
    public static ModuleSlot ModuleSlot8;
    public static ModuleSlot ModuleSlot9;
    public static ModuleSlot ModuleSlot10;
    public static ModuleSlot ModuleSlot11;
    public static ModuleSlot ModuleSlot12;
    public static ModuleSlot ModuleSlot13;
    public static ModuleSlot ModuleSlot14;
    public static ModuleSlot ModuleSlot15;
    public static ModuleSlot ModuleSlot16;
    public static ModuleSlot ModuleSlot17;
    public static ModuleSlot ModuleSlot18;
    public static ModuleSlot ModuleSlot19;
    public static ModuleSlot ModuleSlot20;
    public static ModuleSlot ModuleSlot21;
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
        ModuleSlot8 = slot8.GetComponent<ModuleSlot>();
        ModuleSlot9 = slot9.GetComponent<ModuleSlot>();
        ModuleSlot10 = slot10.GetComponent<ModuleSlot>();
        ModuleSlot11 = slot11.GetComponent<ModuleSlot>();
        ModuleSlot12 = slot12.GetComponent<ModuleSlot>();
        ModuleSlot13 = slot13.GetComponent<ModuleSlot>();
        ModuleSlot14 = slot14.GetComponent<ModuleSlot>();
        ModuleSlot15 = slot15.GetComponent<ModuleSlot>();
        ModuleSlot16 = slot16.GetComponent<ModuleSlot>();
        ModuleSlot17 = slot17.GetComponent<ModuleSlot>();
        ModuleSlot18 = slot18.GetComponent<ModuleSlot>();
        ModuleSlot19 = slot19.GetComponent<ModuleSlot>();
        ModuleSlot20 = slot20.GetComponent<ModuleSlot>();
        ModuleSlot21 = slot21.GetComponent<ModuleSlot>();
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
        ModuleSlot8.setSlot(Inventory.moduleList[7]);
        ModuleSlot9.setSlot(Inventory.moduleList[8]);
        ModuleSlot10.setSlot(Inventory.moduleList[9]);
        ModuleSlot11.setSlot(Inventory.moduleList[10]);
        ModuleSlot12.setSlot(Inventory.moduleList[11]);
        ModuleSlot13.setSlot(Inventory.moduleList[12]);
        ModuleSlot14.setSlot(Inventory.moduleList[13]);
        ModuleSlot15.setSlot(Inventory.moduleList[14]);
        ModuleSlot16.setSlot(Inventory.moduleList[15]);
        ModuleSlot17.setSlot(Inventory.moduleList[16]);
        ModuleSlot18.setSlot(Inventory.moduleList[17]);
        ModuleSlot19.setSlot(Inventory.moduleList[18]);
        ModuleSlot20.setSlot(Inventory.moduleList[19]);
        ModuleSlot21.setSlot(Inventory.moduleList[20]);
        Debug.Log("inventory updated");
    }
    */

