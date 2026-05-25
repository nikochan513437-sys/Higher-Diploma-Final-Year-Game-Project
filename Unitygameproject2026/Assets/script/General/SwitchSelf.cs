using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSelf : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    public void switchSelf()
    {
        self.SetActive(!self.activeSelf);
    }
}
