using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModuleShowInfo : MonoBehaviour, IPointerClickHandler
{
    public ModuleSlot slot;
    public GameObject infoPanel;
    public Text moduleName;
    public Text description;
    public void OnPointerClick(PointerEventData eventData)
    {
        //when right click on the module in module slot,show the module info,data get from the scriptable object
        Debug.Log("click on");
        if (eventData.button == PointerEventData.InputButton.Right&&!slot.slot.moduleName.Equals("NoModule"))
        {
            infoPanel.SetActive(true);
            moduleName.text = slot.slot.moduleName;
            description.text = slot.slot.moduleInfo;
        }
    }
}
