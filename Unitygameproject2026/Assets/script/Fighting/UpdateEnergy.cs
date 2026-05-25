using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnergy : MonoBehaviour
{
    public Text energyText1;
    public Text energyText2;
    public Text energyText3;
    public Text energyText4;
    public void UpdateE()
    {
        int MaxE=0;
        int E=0;
        MaxE = BattleManage.MaxE1;
        E = BattleManage.E1;
        energyText1.text = (E + "/" + MaxE);
        MaxE = BattleManage.MaxE2;
        E = BattleManage.E2;
        energyText2.text = (E + "/" + MaxE);
        MaxE = BattleManage.MaxE3;
        E = BattleManage.E3;
        energyText3.text = (E + "/" + MaxE);
        MaxE = BattleManage.MaxE4;
        E = BattleManage.E4;
        energyText4.text = (E + "/" + MaxE);
    }
}
