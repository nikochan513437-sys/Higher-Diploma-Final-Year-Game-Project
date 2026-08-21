using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    public Button button;
    public GameObject MainCam;
    public GameObject currentCam;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void Start()
    {
        button.interactable = false;
        MainCam = GameObject.Find("Main Camera-GameMap");
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "Event" || scene.name == "Shop" || scene.name == "Fighting")
        {
            button.interactable = true;
            currentCam = GameObject.Find("Main Camera");
        }
    }

    void OnSceneUnloaded(Scene scene)
    {
        if (scene.name == "Event" || scene.name == "Shop" || scene.name == "Fighting")
        {
            button.interactable = false;
        }
    }
    public void ChangeCamera()
    {
        if (!MainCam.activeSelf)
        {
            MainCam.SetActive(true);
            currentCam.SetActive(false);
        }
        else
        {
            currentCam.SetActive(true);
            MainCam.SetActive(false);
        }
    }
}

