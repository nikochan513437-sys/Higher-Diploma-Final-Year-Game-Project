using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "List", menuName = "List")]
public class CreateNewList: ScriptableObject
{
    public List<GameObject> List = new List<GameObject>();
}
//can create a scirptable object to storage all the card in this list