using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGSkip : MonoBehaviour
{
    public string loadto= "SceneStart";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(loadto);
    }

}
//function of skip button
