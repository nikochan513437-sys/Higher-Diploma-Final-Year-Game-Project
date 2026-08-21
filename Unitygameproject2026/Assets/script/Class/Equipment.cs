using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New equipment", menuName = "Equipment/New equipment")]
public class Equipment : ScriptableObject
{
    public string equipName;
    public Sprite equipImage;
    public string equipRarity;
    [TextArea]
    public string equipInfo;
    public string equipType;
}