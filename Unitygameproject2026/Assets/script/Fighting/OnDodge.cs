using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnDodge : MonoBehaviour
{
    public GameObject dodge1;
    public static GameObject dodge;

    private void Awake()
    {
        dodge = dodge1;
        
    }
    public static void onDodge() {
        dodge.SetActive(true);
        RectTransform rectTransform = dodge.GetComponent<RectTransform>();
        rectTransform.DOAnchorPos(new Vector2(-465, 149), 0.5f).OnComplete(() =>
        {
            dodge.SetActive(false);
        });
    }
}
