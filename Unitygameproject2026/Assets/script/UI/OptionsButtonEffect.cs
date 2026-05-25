using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonEffect : MonoBehaviour
{
    public GameObject panel;
    private Button btn;
   
    void Start()
    {
        btn = GetComponent<Button>();

        if (panel != null)
            panel.SetActive(false);

        if (btn != null)
        {
            btn.onClick.AddListener(OnClick);
        }
        
    }


    void OnMouseDown()
    {
        if (!panel.activeSelf)
            panel.SetActive(true);
    }

    public void HideCanvas() {
        panel.SetActive(false);
    }

    void OnClick() {
        if (!panel.activeSelf)
            panel.SetActive(true);
    }
}
