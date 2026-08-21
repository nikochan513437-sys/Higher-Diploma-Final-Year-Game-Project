using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "List", menuName = "ImageList")]
public class CreateImageList : ScriptableObject
{
    public List<Sprite> List = new List<Sprite>();
}
//can create a scirptable object to storage all the card in this list