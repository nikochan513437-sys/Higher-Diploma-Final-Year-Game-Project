using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public CreateNewList NormalEnemyList;
    public CreateNewList EliteEnemyList;
    public CreateNewList BossEnemyList;
    public CreateNewList TutorEnemyList;
    public static float posx;
    public static float posy;
    public void Start()
    {
        Vector3 currentPos = transform.position;
        posx = currentPos.x;
        posy = currentPos.y;
        if (GameManage.tutorMode)
        {
            spawnEnemyTutor();
        }
        else
        {
            spawnEnemyByIndex();
        }
    }
    public void spawnEnemyByIndex()
    {
        CreateNewList list=NormalEnemyList;
        int playerplace = (PlayerPlaceManage.playerPlaceY-1) * 8 + PlayerPlaceManage.playerPlaceX;
        Debug.Log("place x"+PlayerPlaceManage.playerPlaceX);
        Debug.Log("place y"+PlayerPlaceManage.playerPlaceY);
        Debug.Log("place index"+playerplace);
        if (GameManage.MapPoints[playerplace].pointType==1)
        {
            list=NormalEnemyList;
        }
        else if(GameManage.MapPoints[playerplace].pointType == 4)
        {
            list= EliteEnemyList;
        }
        else if(GameManage.MapPoints[playerplace].pointType == 5)
        {
            list= BossEnemyList;
        }

            int index;
        index=GameManage.randNumber() % list.List.Count;
        Debug.Log(index);
        Instantiate(list.List[index], new Vector3(posx, posy,-2), Quaternion.identity,this.gameObject.transform);
        Debug.Log("Enemy Spawned");
    }
    public void spawnEnemyTutor()
    {
        CreateNewList list =TutorEnemyList;
        int playerplace = (PlayerPlaceManage.playerPlaceY - 1) * 8 + PlayerPlaceManage.playerPlaceX;
        if (GameManage.MapPoints[playerplace].pointType == 1)
        {
            Instantiate(list.List[0], new Vector3(posx, posy,-2), Quaternion.identity, this.gameObject.transform);
        }
        else if (GameManage.MapPoints[playerplace].pointType == 5)
        {
            Instantiate(list.List[1], new Vector3(posx, posy,-2), Quaternion.identity, this.gameObject.transform);
        }
    }
}
