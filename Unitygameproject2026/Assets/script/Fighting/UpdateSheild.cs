using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSheild : MonoBehaviour
{
    public Text sheild;
    public void UpdateS()
    {
        sheild.text=BattleManage.Sheild.ToString();
    }
}
