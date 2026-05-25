using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardList", menuName = "Card/CardList")]
public class CardList: ScriptableObject
{
    public List<GameObject> cardList = new List<GameObject>();
}
//can create a scirptable object to storage all the card in this list