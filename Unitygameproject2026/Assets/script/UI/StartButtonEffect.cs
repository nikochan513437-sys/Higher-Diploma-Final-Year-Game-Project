using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonEffect : MonoBehaviour
{
    public GameObject panel;
    public string loadto;
    void OnMouseDown()
    {
        if (!panel.activeSelf)
        {
            Debug.Log("clicked on");
            Reset.reset();
            SceneManager.LoadScene(loadto);
        }
    }
}
