using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthNum;
    public void UpdateH()
    {
        healthSlider.maxValue = BattleManage.MaxHealth;
        healthSlider.value = BattleManage.Health;
        healthNum.text = BattleManage.Health + "/" + BattleManage.MaxHealth;
    }
}
