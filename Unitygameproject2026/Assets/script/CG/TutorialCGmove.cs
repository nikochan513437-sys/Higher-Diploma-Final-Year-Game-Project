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
    public GameObject[] photoList;
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
        "在这段黄金时期，最繁华的「香港星区」诞生了，在油尖旺的星港上，高高飘扬着红底白花的洋紫荆区旗。",
        "这个星区由三大传奇守护：武林宗师李小龙以双节棍横扫星海，赌神周润发用量子扑克掌控命运。",
        "更有喜剧之王周星驰，用无人能懂的无里头无谐能量，强行扭曲着宇宙的物理法则……",
        "他们的领袖——精灵王子，在永恒之光中窥见了......",
        "...但那是只有后人才知晓的秘密。",
        "第一文明的鼎盛期，持续了万年之久。",
        "直到那一天——大崩解降临。",
        "在大崩解的末日风暴中，周星驰大笑一声，用无厘头神力强行撕开了一条时空虫洞，带领整座香港星区遁入平行宇宙。",
        "第一文明的帝国，一日之间化为尘埃。",
        "在大崩解的废墟上，星际霸权崛起。他们垄断了残存的永恒之光和部分其他能量。",
        "如今宇宙波动，香港星区带着熟悉的霓虹大排档、飘扬的洋紫荆旗与秘制咖哩鱼蛋，从虫洞中震撼归来！",
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
            photo = photoList[photonum];
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
            if (txtindex < txt[photonum].Length && wait <= 0)
            {
                messageText.text += txt[photonum][txtindex];
                txtindex++;
                wait = waitingtime;
            }
            if (photo.transform.position.y-y<3) {
                photo.transform.Translate(0, speed * Time.deltaTime*timespeed, 0);
            }
            else if ((Input.GetMouseButtonDown(0)||(Input.anyKeyDown&&!Input.GetKeyDown(KeyCode.Escape))) && txtindex >= txt[photonum].Length && !panel.activeSelf)
            {
                if (photonum == 14)
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
        photonum = 0;
        TutorialCGSound.playonce = true;
        set = 0;
        photo = GameObject.Find("CG1");
        photo.transform.position = new Vector3(0, -5, -11);
        photo = GameObject.Find("CG2");
        photo.transform.position = new Vector3(0.5f, -2, -11);
        photo = GameObject.Find("CG3");
        photo.transform.position = new Vector3(0, -2.5f, -11);
        photo = GameObject.Find("CG3.1");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG3.2");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG3.3");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG4");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG5");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG6");
        photo.transform.position = new Vector3(0, -1.5f, -11);
        photo = GameObject.Find("CG7");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG7.1");
        photo.transform.position = new Vector3(2, -2, -11);
        photo = GameObject.Find("CG8");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG9");
        photo.transform.position = new Vector3(0, -1.5f, -11);
        photo = GameObject.Find("CG9.1");
        photo.transform.position = new Vector3(0, -2, -11);
        photo = GameObject.Find("CG10");
        photo.transform.position = new Vector3(0, -2, -11);
    }
}
