using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModuleUseEquip : MonoBehaviour, IPointerClickHandler
{
    public ModuleSlot slot;
    public static int useDodge = 0;
    public static bool equipUsed = false;

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left) {
            if (SetEquipment.isEquipped && slot.moduleTypeLimit == "DEF" && equipUsed == false )
            {
                Debug.Log("use dodge");
                useDodge = 1;
                equipUsed = true;
                BattleManage.isDodge = equipUsed;
                Destroy(BattleManage.dodge1);
            }
        }
    }

    public static void ResetEquipment() {
        useDodge = 0;
    }

}
