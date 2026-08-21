using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SetEquipment
{
    
    public static bool isEquipped {  get; private set; }

    public static void SetEquip(bool value) {
        isEquipped = value;
    }
}
