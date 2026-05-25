using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    float x, y, z;
    //public GameObject selfObject;
    public int slotnum;
    public ModuleInventory inventory;
    GameObject otherObject;
    ModuleSlot slot1;
    ModuleSlot otherSlot;
    public CanvasGroup slotui;
    void Start()
    {
        //get the module place in
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        z = transform.localPosition.z;
        slot1=this.gameObject.GetComponent<ModuleSlot>();
    }
    void Update()
    {
        //drag module need to not in battle
        if (!BattleManage.inBattle)
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //begin drag,can move the module by drag
        if (!slot1.slot.moduleName.Equals("NoModule"))
        {
            transform.position = eventData.position;
            slotui.blocksRaycasts = false;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //on drag,detect the place that mouse drag,if the place has Modlueslot class,save it in otherobject
        otherObject = eventData.pointerCurrentRaycast.gameObject;
        if (!slot1.slot.moduleName.Equals("NoModule"))
        {
            transform.position = eventData.position;
            transform.SetAsLastSibling();
        }
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //end of drag,if the place that mouse drag is vaild,use changeslot to change the data,then reset the place that module at
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<ModuleSlot>() && this != otherObject )
        {
            otherSlot = eventData.pointerCurrentRaycast.gameObject.GetComponent<ModuleSlot>();
            if (slot1.slot.moduleType.Equals(otherSlot.moduleTypeLimit) || otherSlot.moduleTypeLimit.Equals("Any"))
            {
                changeSlot();
            }
        }
        transform.localPosition = new Vector3(x, y, z);
        slotui.blocksRaycasts = true;
    }
    public void changeSlot()
    {  
        //if drag module to change place success,move the data of module
        if (otherSlot.slot == otherSlot.noModule)
        {
            //otherSlot.setSlot(slot1.slot);
            otherObject.GetComponent<Drag>().inventory.moduleList[otherObject.GetComponent<Drag>().slotnum] = inventory.moduleList[slotnum];
            //slot1.setSlot(slot1.noModule);
            inventory.moduleList[slotnum]=slot1.noModule;
            Debug.Log("This slot have no module");
        }
        else if(otherSlot.slot != otherSlot.noModule)
        {
            //Module temp = otherSlot.slot;
            GameObject temp1 = otherObject;
            //otherSlot.setSlot(slot1.slot);
            otherObject.GetComponent<Drag>().inventory.moduleList[otherObject.GetComponent<Drag>().slotnum] = inventory.moduleList[slotnum];
            //slot1.setSlot(temp);
            inventory.moduleList[slotnum] = temp1.GetComponent<Drag>().inventory.moduleList[otherObject.GetComponent<Drag>().slotnum];
            Debug.Log("This slot have module");
        }
        //update data in scripable object
        ModuleManage.UpdateInventory();
        ModuleBackpack.UpdateBackpack();
    }
}
