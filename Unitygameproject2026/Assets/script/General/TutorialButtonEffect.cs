using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtonEffect : MonoBehaviour
{
    public GameObject panel;
    public string loadto = "TutorialCG";
    
    void OnMouseDown()
    {
        if (!panel.activeSelf)
        {
            Debug.Log("clicked on");
            Reset.reset();
            SceneManager.LoadScene(loadto);
        }
    }

    void OnClick()
    {
        if (!panel.activeSelf)
            SceneManager.LoadScene(loadto);
    }
}
