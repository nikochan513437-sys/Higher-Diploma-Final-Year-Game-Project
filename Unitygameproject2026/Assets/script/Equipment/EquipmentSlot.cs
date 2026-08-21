using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Equipment noEquip;
    public Equipment slot;
    public Image Image;
    public string moduleTypeLimit;
    public void Start()
    {
        if (slot == null)
        {
            slot = noEquip;
        }
        setImage(slot.equipImage);
    }
    EquipmentSlot(Equipment slot)
    {
        this.slot = slot;
    }
    public void setSlot(Equipment equipment)
    {
        //slot = Equ;
        slot = equipment;
        setImage(slot.equipImage);
        //when modlue slot be set,update the image of the slot
    }
    public void setImage(Sprite image)
    {
       Image.sprite = image;
    }
}
//a class module slot,to show the image and storage the module in the slot