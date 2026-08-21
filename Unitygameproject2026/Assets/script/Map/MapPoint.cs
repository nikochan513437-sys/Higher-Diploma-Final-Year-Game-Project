using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapPoint : MonoBehaviour
{
    public int pointType;
    public int pointIndex;
    public Sprite image;
    public SpriteRenderer spriteRender;
    public bool isEnd = false;
    public Color nowColor;

    public void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        nowColor = spriteRender.color;
    }
    public void Update()
    {
        setPointImage();
    }
    public void setPointType(int type)
    {
        pointType = type;
        setPointImage();
    }
    public void setPointImage()
    {
        spriteRender.sprite = image;
    }

    /*public bool IsAdjacentToPlayer(int current, int target)
    {
        int currentWidth = 7;

        int curX = current % currentWidth;
        int curY = current / currentWidth;
        int tarX = target % currentWidth;
        int tarY = target / currentWidth;
        int distX = Mathf.Abs(curX - tarX);
        int disty = Mathf.Abs(curY - tarY);
        return (distX == 1 && disty == 0) || (disty == 1 && distX == 0);
    }*/
    public bool canChoose()
    {
        int ptX = pointIndex % 8;
        int ptY = 1 + pointIndex / 8;
        if (ptX == PlayerPlaceManage.playerPlaceX && ptY == PlayerPlaceManage.playerPlaceY + 1)
        {
            return true;
        }
        if(ptX == PlayerPlaceManage.playerPlaceX && ptY == PlayerPlaceManage.playerPlaceY - 1)
        {
            return true;
        }
        if (ptX == PlayerPlaceManage.playerPlaceX+1 && ptY == PlayerPlaceManage.playerPlaceY)
        {
            return true;
        }
        if (ptX == PlayerPlaceManage.playerPlaceX-1 && ptY == PlayerPlaceManage.playerPlaceY)
        {
            return true;
        }
        return false;
    }
    public void OnMouseDown()
    {
        Debug.Log("pty="+ (1 + pointIndex / 8));
        Debug.Log("ptx=" + (pointIndex % 8));
        //if (!IsAdjacentToPlayer(GameManage.PlayerPlace, pointIndex)) return;
        if (canChoose() && BattleManage.inBattle == false && ShopManage.inShop == false && EventManage.inEvent == false && GameManage.CanAct())
        {
            GameManage.PlayerMove(pointIndex);
            PlayerPlaceManage.PlayerPlaceMove(pointIndex);
            if (!isEnd)
            {
                
                if (pointType == 1)
                {
                    Debug.Log("Loading into fighting");
                    GameObject.Find("Gamemanage").GetComponent<LoadScene>().LoadNewScene("fighting");
                    isEnd = true;
                }
                if (pointType == 2)
                {
                    GameObject.Find("Gamemanage").GetComponent<LoadScene>().LoadNewScene("Event");
                    isEnd = true;
                }
                if (pointType == 3)
                {
                    GameObject.Find("Gamemanage").GetComponent<LoadScene>().LoadNewScene("Shop");
                }
                if (pointType == 4)
                {
                    GameObject.Find("Gamemanage").GetComponent<LoadScene>().LoadNewScene("fighting");
                    isEnd = true;
                }
                if (pointType == 5)
                {
                    GameObject.Find("Gamemanage").GetComponent<LoadScene>().LoadNewScene("fighting");
                }

            }
            if (pointType != 0 && pointType != 3)
            {
                nowColor.a = 0.4f;
                spriteRender.color = nowColor;
            }
        }
    }
    
}
