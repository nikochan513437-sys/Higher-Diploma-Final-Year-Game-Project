using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscOpenSetting : MonoBehaviour
{
    public GameObject panel;
    public GameObject optionsPanel;
    public GameObject dialog;

    private void Start()
    {
        if (panel != null)
            panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        bool dialogInactive = (dialog == null || !dialog.activeSelf);
        if (Input.GetKeyDown(KeyCode.Escape) && !optionsPanel.activeSelf && dialogInactive)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
    public void OpenSettingPanel()
    {
        if (panel != null)
            panel.SetActive(!panel.activeSelf);
    }
}
