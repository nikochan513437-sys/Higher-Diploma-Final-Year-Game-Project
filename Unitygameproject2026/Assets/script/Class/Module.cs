using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New module",menuName ="Module/New modlue")]
public class Module : ScriptableObject
{
    public string moduleName;
    public Sprite moduleImage;
    public string cardRarity;//稀有度有starter(初始),carft(合成),common(普通),uncommon(罕见),rare(稀有),unique(独特)
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