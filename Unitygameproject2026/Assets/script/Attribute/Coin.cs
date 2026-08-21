using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coin = 0;

    public static Text coinTxt;
     

    void Awake()
    {
        if (coinTxt == null)
            coinTxt = GetComponent<Text>();
    }
    public static void AddCoin(int num) {
        coin += num;
        updateCoin();
    }

    public static void ReduceCoin(int num)
    {
        coin -= num;
        updateCoin();
    }

    public static void ResetCoin()
    {
        coin = 000;
        updateCoin();
    }

    public static void updateCoin() {
        if (coinTxt != null) {
            coinTxt.text = coin.ToString();
        }
    }
}
