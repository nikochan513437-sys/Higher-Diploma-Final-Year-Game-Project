using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButtonEffect : MonoBehaviour
{
    public GameObject equipPanel, escPanel, dialog;
    public string loadto;
    public static bool enemyCanClick = true;
    public static bool eventCanClick = false;
    public static bool shopCanClick = false;
    public static bool bossCanClick = false;

    void Start()
    {
        equipPanel = Canvas1.instance.transform.Find("Inventory-EquipPanel").gameObject;
        escPanel = Canvas1.instance.transform.Find("EscPanel").gameObject;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color nowColor = sr.color;

        if (gameObject.name == "Button-Enemy" && (eventCanClick || bossCanClick || shopCanClick))
        {
            nowColor.a = 0.4f;
            sr.color = nowColor;

        }
        if (gameObject.name == "Button-Event" && (bossCanClick || shopCanClick))
        {
            nowColor.a = 0.4f;
            sr.color = nowColor;
        }
        if (gameObject.name == "Button-Shop" && bossCanClick)
        {
            nowColor.a = 0.4f;
            sr.color = nowColor;
        }
    } //check which button can be pressed when entering the scene.

    void OnMouseDown()
    {
        if (!dialog.activeSelf && !escPanel.activeSelf && !equipPanel.activeSelf)
        {
            if (gameObject.name == "Button-Enemy" && enemyCanClick)
            {
                enemyCanClick = false;
                eventCanClick = true;
                BattleManage.isboss = false;
                SceneManager.LoadScene(loadto);
            }
            if (gameObject.name == "Button-Event" && eventCanClick)
            {
                eventCanClick = false;
                shopCanClick = true;
                SceneManager.LoadScene(loadto);
            }
            if (gameObject.name == "Button-Shop" && shopCanClick){
                shopCanClick = false;
                bossCanClick = true;
                SceneManager.LoadScene(loadto);
            }
        }
    }

    void OnClick()
    {
        if (!equipPanel.activeSelf && !escPanel.activeSelf)
        {
            SceneManager.LoadScene(loadto, LoadSceneMode.Additive);
        }
    }

}
