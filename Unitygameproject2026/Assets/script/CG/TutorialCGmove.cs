using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialCGmove : MonoBehaviour
{
    public static int photonum=0;
    int set = 0;
    GameObject photo;
    Vector2 pos;
    float x;
    float y;
    float speed = 0.8f;
    public Text messageText;
    public float timespeed = 1;
    public string loadto = "SceneStart";
    public GameObject panel;
    int txtindex;
    float waitingtime = 0.1f;
    float wait;
    string[] txt = {
        "在宇宙黎明之初，创世巨神——『最初者』，从虚空中苏醒。",
        "祂以无上意志，铸造了星河之路，灌注了四种原初能量。",
        "于是，第一文明诞生了。他们是光的宠儿，被称为『光铸者』。",
        "他们的领袖——精灵王子，在永恒之光中窥见了......",
        "...但那是只有后人才知晓的秘密。",
        "第一文明的鼎盛期，持续了万年之久。",
        "直到那一天——大崩解降临。",
        "第一文明的帝国，一日之间化为尘埃。",
        "在大崩解的废墟上，星际霸权崛起。他们垄断了残存的永恒之光和部分其他能量。",
        "而你——将穿梭于破碎的星河之间，追寻那失落的光" ,
        ""
    };
// Start is called before the first frame update
    void Start() {
        ResetScene();
        //reset tutorial CG at start
    }

    void Update()
    {
        if (set == 0)//if reset,to setup 
        {
            messageText.text = "";
            txtindex = 0;
            wait = waitingtime;
            photo = GameObject.Find("CG" + photonum);
            pos= photo.transform.position;
            x= pos.x;
            y= pos.y;
            photo.transform.position = new Vector3(x,y,-1);
            set = 1;
            Debug.Log(txt[photonum].Length);
        }
        else
        {
            //if setup,show the CG ,move and show text
            wait -= Time.deltaTime * timespeed;
            if (txtindex < txt[photonum-1].Length && wait <= 0)
            {
                messageText.text += txt[photonum-1][txtindex];
                txtindex++;
                wait = waitingtime;
            }
            if (photo.transform.position.y-y<3) {
                photo.transform.Translate(0, speed * Time.deltaTime*timespeed, 0);
            }
            else if ((Input.GetMouseButtonDown(0)||(Input.anyKeyDown&&!Input.GetKeyDown(KeyCode.Escape))) && txtindex >= txt[photonum - 1].Length && !panel.activeSelf)
            {
                if (photonum == 10)
                {
                    SceneManager.LoadScene(loadto);
                }
                set = 0;
                photo.transform.position = new Vector3(x, y, -11);
                photonum++;
                TutorialCGSound.playonce = true;
            }
        }
    }
    //reset
    public void ResetScene()
    {
        photonum = 1;
        TutorialCGSound.playonce = true;
        set = 0;
        photo = GameObject.Find("CG1");
        photo.transform.position = new Vector3(0, -5, -11);
        photo = GameObject.Find("CG2");
        photo.transform.position = new Vector3(0.5f, -2, -11);
        photo = GameObject.Find("CG3");
        photo.transform.position = new Vector3(0, -2.5f, -11);
        photo = GameObject.Find("CG4");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG5");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG6");
        photo.transform.position = new Vector3(0, -1.5f, -11);
        photo = GameObject.Find("CG7");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG8");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG9");
        photo.transform.position = new Vector3(0, -1.5f, -11);
        photo = GameObject.Find("CG10");
        photo.transform.position = new Vector3(0, -2, -11);
    }
}
