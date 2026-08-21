using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManage : MonoBehaviour
{
    public static bool inShop = false;
    public GameObject MainCam;
    public static int craftPrice=100;
    public static int commonPrice=300;
    public static int uncommonPrice=500;
    public static int rarePrice=1000;
    public ModuleInventory shopList1;
    public ModuleInventory shopList2;
    public GameObject tutorSlot;
    public ModuleSlot[] shopSlot = new ModuleSlot[4];
    public Text[] Text=new Text[4];
    public void Start()
    {
        MainCam = GameObject.Find("Main Camera-GameMap");
        MainCam.SetActive(false);
        inShop = true;

        if (SceneManager.GetSceneByName("GameMap").isLoaded)
        {
            tutorSlot.SetActive(false);
            if (PlayerPlaceManage.playerPlaceX == 2)
            {
                for(int i = 0; i < shopSlot.Length; i++)
                {
                    shopSlot[i].setSlot(shopList1.moduleList[i]);
                }
            }
            if (PlayerPlaceManage.playerPlaceX == 5)
            {
                for (int i = 0; i < shopSlot.Length; i++)
                {
                    shopSlot[i].setSlot(shopList2.moduleList[i]);
                }
            }
            for (int i = 0;  i < 4; i++)
            {
                if (shopSlot[i].slot.cardRarity.Equals("craft"))
                {
                    Text[i].text = craftPrice.ToString();
                }
                if (shopSlot[i].slot.cardRarity.Equals("common"))
                {
                    Text[i].text = commonPrice.ToString();
                }
                if (shopSlot[i].slot.cardRarity.Equals("uncommon"))
                {
                    Text[i].text = uncommonPrice.ToString();
                }
                if (shopSlot[i].slot.cardRarity.Equals("rare"))
                {
                    Text[i].text = rarePrice.ToString();
                }
            }
        }
        else
        {
            tutorSlot.SetActive(true);
        }
    }

    public void ExitShop()
    {
        inShop = false;
        MainCam.SetActive(true);
        SceneManager.UnloadSceneAsync("Shop");
    }
}