using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public static int MapSizeX = 8;
    public static int MapSizeY = 5;
    public static int PlayerPlace;
    public static int[] Map = new int[MapSizeX*MapSizeY];
    public static int gameSeed;
    public static bool tutorMode = false;
    public static MapPoint[] MapPoints=new MapPoint[MapSizeX * MapSizeY];
    public static CreateImageList MapPointImage;
    public MapPoint[] MapPointList;
    public CreateImageList mapPointImage;
    public GameObject player1;
    public static GameObject player;
    public static GameObject resultPanel;
    public GameObject resultPanel1;
    public static GameObject escPanel;
    public GameObject escPanel1;
    public static GameObject equipPanel;
    public GameObject equipPanel1;
    public static GameObject baseCoinObj;
    public GameObject baseCoinObj1;
    public static GameObject bonusCoinObj;
    public GameObject bonusCoinObj1;
    public static int baseCoin;
    public static int bonusCoin;
    public static Text baseCoinTxt;
    public static Text bonusCoinTxt;
    public Text baseCoinTxt1;
    public Text bonusCoinTxt1;

    public static Image moduleRewardImg;
    public Image moduleRewardImg1;
    public static Module rewardModule;
    public Module noModule;

    public ModuleInventory moduleList;
    public ModuleInventory moduleBackpack;
    public ModuleInventory shopModule1;
    public ModuleInventory shopModule2;

    public void Start()
    {
        baseCoinObj = baseCoinObj1;
        bonusCoinObj = bonusCoinObj1;
        player = player1;
        resultPanel = resultPanel1;
        escPanel = escPanel1;
        equipPanel = equipPanel1;
        MapPointImage = mapPointImage; 
        MapPoints = MapPointList;
        baseCoinTxt = baseCoinTxt1;
        bonusCoinTxt = bonusCoinTxt1;
        moduleRewardImg = moduleRewardImg1;

        SetMapSeed();
        if (SceneManager.GetActiveScene().name == "GameMap")
        {
            GameMapSpwan();
            resetShopList();
            CameraMove cam = FindObjectOfType<CameraMove>();
            if (cam != null)
            {
                cam.FocusOnPlayer(PlayerPlace);
            }
            tutorMode = false;
        }
        else
        {
            PlayerPlace = 0;
            PlayerPlaceManage.PlayerPlaceMove(0);
            tutorMode = true;
        }
        
    }
    public static int randNumber()
    {
        return Random.Range(0, int.MaxValue);
    }
    public static void setMapPoint(int num,int type)
    {
        Map[num] = type;
        MapPoints[num].image = MapPointImage.List[type];
        MapPoints[num].setPointType(type);
    }
    public static void reloadMap()
    {
        for(int i = 0; i < Map.Length; i++)
        {
            MapPoints[i]= GameObject.Find("MapPoint["+(int)(i/8+1)+"]["+(int)(i%8)+"]").GetComponent<MapPoint>();
        }
        for (int i = 0; i < Map.Length; i++)
        {
            setMapPoint(i, Map[i]);
        }
    }
    public static void PlayerMove(int index)
    {
        PlayerPlace = index;

        float xOffset = 3f; 
        float yOffset = -3f;
        Vector3 targetPos = MapPoints[PlayerPlace].transform.position;
        player.transform.position = new Vector3(targetPos.x + xOffset, targetPos.y + yOffset, -0.1f);
    }
    public void SetMapSeed()
    {
        int nowTime = (int)System.DateTimeOffset.Now.ToUnixTimeSeconds();
        Random.InitState(nowTime);
        gameSeed = randNumber();
        Random.InitState(gameSeed);
    }

    public void InitializePlayerPosition() {
        Vector3 targetPos = MapPoints[PlayerPlace].transform.position;
        player.transform.position = new Vector3(targetPos.x, targetPos.y, -0.1f);
    }

    public static bool CanAct() {
        if (resultPanel.activeSelf || escPanel.activeSelf || equipPanel.activeSelf)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static void ResultPanel(int baseCoin1, int bonusCoin1) {
        baseCoin = baseCoin1;
        bonusCoin = bonusCoin1;
        if (baseCoin1 == 0 && bonusCoin1 == 0)
        {
            baseCoinObj.SetActive(false);
            bonusCoinObj.SetActive(false);
        }
        else if (bonusCoin1 == 0)
        {
            bonusCoinObj.SetActive(false);
            baseCoinObj.SetActive(true);
        }
        else if (baseCoin1 == 0)
        {
            baseCoinObj.SetActive(false);
            bonusCoinObj.SetActive(true);
        }
        else {
            baseCoinObj.SetActive(true);
            bonusCoinObj.SetActive(true);
        }

        baseCoinTxt.text = baseCoin1.ToString();
        bonusCoinTxt.text = bonusCoin1.ToString() + " (Bonus)";

        GameObject.FindObjectOfType<GameManage>().getRandomModule();
        resultPanel.SetActive(true);
    }

    public void getRandomModule()
    {
        int moduleIndex = randNumber() % moduleList.moduleList.Count;
        if (!moduleList.moduleList[moduleIndex].cardRarity.Equals("starter"))
        {
            rewardModule = moduleList.moduleList[moduleIndex];
            if (moduleRewardImg != null && rewardModule != null)
            {
                moduleRewardImg.sprite = rewardModule.moduleImage;
                moduleRewardImg.gameObject.SetActive(true);
            }
        }
        else
        {
            getRandomModule();
        }
        
    }
        
    public void resetShopList()
    {
        for (int i = 0; i <shopModule1.moduleList.Count; i++)
        {
            
            shopModule1.moduleList[i] = moduleList.moduleList[randNumber()%(moduleList.moduleList.Count)];
        }
        for (int i = 0; i < shopModule1.moduleList.Count; i++)
        {
            shopModule2.moduleList[i] = moduleList.moduleList[randNumber() % (moduleList.moduleList.Count)];
        }
    }
    public void ConfirmButton() {
        Coin.AddCoin(baseCoin + bonusCoin);
        for (int i = 0; i < moduleBackpack.moduleList.Count; i++)
        {
            if (moduleBackpack.moduleList[i].moduleName.Equals("NoModule"))
            {
                moduleBackpack.moduleList[i] = rewardModule;
                ModuleBackpack.UpdateBackpack();
                break;
            }
        }
        rewardModule = null;
    }

    public void GameMapSpwan()
    {
        int temp=randNumber();
        if (temp%4 == 0)
        {
            setMapPoint(0, 0);
            setMapPoint(39, 5);
            setMapPoint(1,1);
            setMapPoint(8,1);
            setMapPoint(31, 4);
            setMapPoint(38, 4);
            PlayerMove(0);
            PlayerPlaceManage.PlayerPlaceMove(0);
        }
        else if (temp%4 == 1)
        {
            setMapPoint(7, 0);
            setMapPoint(32, 5);
            setMapPoint(6,1);
            setMapPoint(15,1);
            setMapPoint(24, 4);
            setMapPoint(33, 4);
            PlayerMove(7);
            PlayerPlaceManage.PlayerPlaceMove(7);
        }
        else if (temp%4 == 2)
        {
            setMapPoint(32, 0);
            setMapPoint(7, 5);
            setMapPoint(24,1);
            setMapPoint(33,1);
            setMapPoint(6, 4);
            setMapPoint(15, 4);
            PlayerMove(32);
            PlayerPlaceManage.PlayerPlaceMove(32);
        }
        else
        {
            setMapPoint(39, 0);
            setMapPoint(0, 5);
            setMapPoint(31,1);
            setMapPoint(38,1);
            setMapPoint(1, 4);
            setMapPoint(8, 4);
            PlayerMove(39);
            PlayerPlaceManage.PlayerPlaceMove(39);
        }
        setMapPoint(18, 3);
        setMapPoint(21, 3);
        for(int i=0;i< MapSizeX * MapSizeY; i++)
        {
            if (MapPoints[i].pointType == -1)
            {
                temp=randNumber() ;
                if (temp % 100 > 80)
                {
                    setMapPoint(i, 2);
                }
                else
                {
                    setMapPoint(i, 1);
                }
            }
        }
    }
}
