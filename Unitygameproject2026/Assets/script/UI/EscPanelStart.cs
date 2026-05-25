using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscPanelStart : MonoBehaviour
{
    public GameObject panel;
    public void QuitPanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
