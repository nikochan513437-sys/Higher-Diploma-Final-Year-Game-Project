using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Module/New inventory/Backpack")]
public class ModuleInventory : ScriptableObject
{
    public List<Module> moduleList = new List<Module>();
}
//can create a scirptable object module inventory,to storage the module in game
