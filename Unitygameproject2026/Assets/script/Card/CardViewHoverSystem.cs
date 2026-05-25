using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewHoverSystem : MonoBehaviour
{
    [SerializeField] private GameObject atkCardViewHover;
    [SerializeField] private GameObject defCardViewHover;


    public static CardViewHoverSystem instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Show(Vector3 position, int type) {
        if (type == 0)
        {
            atkCardViewHover.gameObject.SetActive(true);
            atkCardViewHover.transform.position = position;
        }
        else if (type == 1) {
            defCardViewHover.gameObject.SetActive(true);
            defCardViewHover.transform.position = position;
        }
    }

    public void Hide() {
        atkCardViewHover.gameObject.SetActive(false);
        defCardViewHover.gameObject.SetActive(false);
    }
}
