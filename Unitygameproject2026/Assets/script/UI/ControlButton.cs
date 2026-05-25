using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    public Button button;
    public GameObject targetComponent;

    void Update()
    {
        if (targetComponent != null && targetComponent.activeSelf)
        {
            button.interactable = false;
        }
        else {
            button.interactable = true;
        }
    }
}
