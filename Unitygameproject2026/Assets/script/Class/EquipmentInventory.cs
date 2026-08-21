using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Equipment/New inventory/Backpack")]
public class EquipmentInventory : ScriptableObject
{
    public List<Equipment> equipList = new List<Equipment>();
}
