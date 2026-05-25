using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModuleSlot : MonoBehaviour
{
    public Module noModule;
    public Module slot;
    public Image Image;
    public string moduleTypeLimit;
    public void Start()
    {
        if (slot == null)
        {
            slot = noModule;
        }
        setImage(slot.moduleImage);
    }
    ModuleSlot(Module slot)
    {
        this.slot = slot;
    }
    public void setSlot(Module module)
    {
        slot = module;
        setImage(slot.moduleImage);
        //when modlue slot be set,update the image of the slot
    }
    public void setImage(Sprite image)
    {
       Image.sprite = image;
    }
}
//a class module slot,to show the image and storage the module in the slot