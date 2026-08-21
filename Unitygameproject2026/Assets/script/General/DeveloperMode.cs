using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    public static bool isDeveloper;
    public GameObject tick;

    public void ChangeDeveloper() {
        isDeveloper = !isDeveloper;
        tick.SetActive(isDeveloper);
    }
}
