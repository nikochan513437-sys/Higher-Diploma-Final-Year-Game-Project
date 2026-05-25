using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionGetVoiceAct : MonoBehaviour
{
    public static bool voiceact=false;
    public GameObject YesNoPanel;
    public GameObject tick;
    private void Start()
    {
        YesNoPanel.SetActive(false);
        UpdateVoiceAct();
    }
    public void UpdateVoiceAct()
    {
        if (voiceact)
        {
            tick.SetActive(true);
        }
        else
        {
            tick.SetActive(false);
        }
        TutorialCGSound.willplay = voiceact;
    }
    public void SwitchVoiceAct()
    {
        if (!voiceact)
        {
            YesNoPanel.SetActive(true);
        }
        else
        {
            voiceact = !voiceact;
            UpdateVoiceAct();
        }
    }
    public void SwitchOnNo()
    {
        YesNoPanel.SetActive(false);
    }
    public void SwitchOnYes()
    {
        YesNoPanel.SetActive(false);
        voiceact = true;
        UpdateVoiceAct();
    }
}
