using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance { get; private set; }

    private float elapsedTime = 0f;
    private bool isTiming = false;
    public GameObject escPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
        }
        if (escPanel.activeSelf)
        {
            StopTimer();
        }
        else {
            StartTimer();
        }
    }

    public void StartTimer() {
        isTiming = true;
    }
    public void StopTimer() {
        isTiming = false;
    }

    public void ResetTimer()
    {
        isTiming = false;
        elapsedTime = 0f;
    }

    public string GetFormattedTime()
    {
        int min = Mathf.FloorToInt(elapsedTime / 60F);
        int sec = Mathf.FloorToInt(elapsedTime % 60F);
        return string.Format("{0:00}:{1:00}", min, sec);
    }

    public float GetTime() { 
        return elapsedTime;
    }
}
