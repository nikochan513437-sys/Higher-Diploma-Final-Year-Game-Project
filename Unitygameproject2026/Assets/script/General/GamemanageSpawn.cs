using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemanageSpawn : MonoBehaviour
{
    public void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "SceneStart")
        {
            Destroy(this);
        }
    }
}
