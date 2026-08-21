using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));

    }
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            // when allowSceneActivation = false,Aprogress max to 0.9f
            if (asyncLoad.progress >= 0.9f)
            {
                //allow active
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;//wait next frame
        }
        Scene nextScene = SceneManager.GetSceneByName(sceneName);
        if (nextScene.IsValid())
        {
            SceneManager.SetActiveScene(nextScene);
        }
    }
}
