using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentBackPack : MonoBehaviour
{
    public EquipmentInventory inventory;
    public GameObject[] slots = new GameObject[21];

    public static EquipmentInventory Inventory;
    public static EquipmentSlot[] EquipSlots;

    public void Start()
    {
        Inventory = inventory;
        EquipSlots = new EquipmentSlot[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            EquipSlots[i] = slots[i].GetComponent<EquipmentSlot>();
        }

        UpdateBackpack();
    }

    public static void UpdateBackpack()
    {

        int updateCount = Mathf.Min(EquipSlots.Length, Inventory.equipList.Count);

        for (int i = 0; i < updateCount; i++)
        {
            if (EquipSlots[i] != null)
            {
                EquipSlots[i].setSlot(Inventory.equipList[i]);
            }
        }

        Debug.Log("Inventory updated");
    }
}
