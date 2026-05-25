using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void switchScene(string sceneName)
    {
        Debug.Log("ChangeScene");
        SceneManager.LoadScene(sceneName);
    }
}
