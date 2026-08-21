using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{/*
    public static LevelManager instance;

    public List<string> level = new List<string>() { "Level1", "Level2", "Level3", "Level4" };

    public static int currentLevelIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
            Destroy(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    } 
     void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int index = level.IndexOf(scene.name);
    }

    public void EnterLevel(string sceneName) {
        int index = level.IndexOf(sceneName);
        if (index == currentLevelIndex)
            SceneManager.LoadScene(sceneName);
    }
    */
}
