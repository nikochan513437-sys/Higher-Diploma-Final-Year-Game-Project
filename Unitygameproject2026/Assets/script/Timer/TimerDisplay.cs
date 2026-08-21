using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private Text timerText;
    private void Awake()
    {
        timerText = GetComponent<Text>();
    }

    private void Start()
    {
        if (GameTimer.Instance != null)
            GameTimer.Instance.StartTimer();
    }

    private void Update()
    {
        timerText.text = GameTimer.Instance.GetFormattedTime();
    }
}
