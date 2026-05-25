using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    public Button button;

    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "Event" || scene.name == "Shop")
        {
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
    }
    public void ChangeToMap() {
       SceneManager.LoadScene("TutorialMap");
    }
}
