using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManage : MonoBehaviour
{
    public static bool inEvent = false;
    public GameObject MainCam;
    void Start()
    {
        MainCam = GameObject.Find("Main Camera-GameMap");
        MainCam.SetActive(false);
        inEvent = true;
    }

    public void ExitEvent()
    {
        inEvent = false;
        MainCam.SetActive(true);
        SceneManager.UnloadSceneAsync("Event");
        GameManage.ResultPanel(0,0);
    }
}
