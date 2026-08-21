using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossButton : MonoBehaviour
{
    void OnMouseDown()
    {
        if (MapButtonEffect.bossCanClick == true)
        {
            //BattleManage.isboss = true;
            SceneManager.LoadScene("Fighting");
        }
    }
}
