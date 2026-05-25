using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyModule : MonoBehaviour
{
    public ModuleInventory inventory;
    public Module cannon2;

    void OnMouseDown()
    {
        Debug.Log("give module");
        inventory.moduleList[0] = cannon2;
        ModuleManage.UpdateInventory();
        ModuleBackpack.UpdateBackpack();
    }
}
