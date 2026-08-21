using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceManage : MonoBehaviour
{
    public static int playerPlaceX=1;
    public static int playerPlaceY=1;
    public static void PlayerPlaceMove(int index)
    {
        playerPlaceX = index % 8;
        playerPlaceY = 1 + (index / 8);
    }
}
