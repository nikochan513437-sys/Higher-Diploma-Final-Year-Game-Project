using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSensitivityControl : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        if (BGMVolumeControl.Instance != null)
        {
            slider.value = BGMVolumeControl.Instance.GetComponent<AudioSource>().volume;
        }
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(ChangedVolume);
    }


    void ChangedVolume(float value)
    {
        if (Setting.Instance != null)
        {
            Setting.Instance.OnVolumeChanged(value);
        }
    }
}
