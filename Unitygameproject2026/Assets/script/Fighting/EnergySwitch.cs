using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySwitch : MonoBehaviour
{
    public GameObject E1;
    public GameObject E2;
    public GameObject E3;
    public GameObject E4;
    public static int Emode = 1;

    void OnMouseDown()
    {
        switchEState();
    }
    public void switchEState()
    {
        Emode++;
        Emode%=4;
        if (Emode == 1)
        {
            E1.SetActive(true);
            E2.SetActive(false);
            E3.SetActive(false);
            E4.SetActive(false);
        }
        else if (Emode == 2)
        {
            E1.SetActive(false);
            E2.SetActive(true);
            E3.SetActive(false);
            E4.SetActive(false);
        }
        else if (Emode == 3)
        {
            E1.SetActive(false);
            E2.SetActive(false);
            E3.SetActive(true);
            E4.SetActive(false);
        }
        else
        {
            E1.SetActive(false);
            E2.SetActive(false);
            E3.SetActive(false);
            E4.SetActive(true);
        }
    }
}
