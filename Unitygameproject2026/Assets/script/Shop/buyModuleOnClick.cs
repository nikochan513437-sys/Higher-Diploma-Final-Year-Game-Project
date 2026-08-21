using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buyModuleOnClick : MonoBehaviour, IPointerClickHandler
{
    public Text price;
    public ModuleInventory backpack;
    public Module noModule;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && !GetComponent<ModuleSlot>().slot.moduleName.Equals("NoModule"))
        {
            int.TryParse(price.text, out int result);
            if (Coin.coin>= result)
            {
                for (int i = 0; i < backpack.moduleList.Count; i++)
                {
                    if (backpack.moduleList[i].moduleName.Equals("NoModule"))
                    {
                        backpack.moduleList[i] = GetComponent<ModuleSlot>().slot;
                        GetComponent<ModuleSlot>().setSlot(noModule);
                        price.text = "";
                    }
                }
                Coin.coin -= result;
                Coin.updateCoin();
                ModuleBackpack.UpdateBackpack();
            }
        }
    }
}