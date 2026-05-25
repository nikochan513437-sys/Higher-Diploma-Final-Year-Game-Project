using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New module",menuName ="Module/New modlue")]
public class Module : ScriptableObject
{
    public string moduleName;
    public Sprite moduleImage;
    [TextArea]
    public string moduleInfo;
    public string moduleType;
    public int moduleArmor;
    public int moduleEnergyLevel;
    public int moduleEnergyNumber;
    public bool willGiveCard;
    public int giveCardNo;
}
//to create a scripable object module(new a module)