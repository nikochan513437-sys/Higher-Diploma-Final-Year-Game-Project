using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardViewHoverSystem : MonoBehaviour
{
    [SerializeField] private GameObject atkCardViewHover;
    [SerializeField] private GameObject defCardViewHover;
    [SerializeField] private GameObject compoundCardViewHover;
    [SerializeField] private GameObject doubleAtkCardViewHover;
    [SerializeField] private GameObject unstableBlastCardViewHover;
    [SerializeField] private GameObject overchargedInsulationCardViewHover;
    [SerializeField] private GameObject tribleAtkCardViewHover;
    [SerializeField] private GameObject stokeTheFalmesCardViewHover;
    [SerializeField] private GameObject meltdownRaysCardViewHover;
    [SerializeField] private GameObject dischargeBoltCardViewHover;
    [SerializeField] private GameObject kineticSlugCardViewHover;
    [SerializeField] private GameObject hVRCardViewHover;
    [SerializeField] private GameObject staticAegisCardViewHover;
    [SerializeField] private GameObject kineticRecyclerCardViewHover;

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
        else if (type == 1)
        {
            defCardViewHover.gameObject.SetActive(true);
            defCardViewHover.transform.position = position;
        }
        else if (type == 2)
        {
            compoundCardViewHover.gameObject.SetActive(true);
            compoundCardViewHover.transform.position = position;
        }
        else if (type == 3)
        {
            doubleAtkCardViewHover.gameObject.SetActive(true);
            doubleAtkCardViewHover.transform.position = position;
        }
        else if (type == 4)
        {
            unstableBlastCardViewHover.gameObject.SetActive(true);
            unstableBlastCardViewHover.transform.position = position;
        }
        else if (type == 5)
        {
            overchargedInsulationCardViewHover.gameObject.SetActive(true);
            overchargedInsulationCardViewHover.transform.position = position;
        }
        else if (type == 6)
        {
            tribleAtkCardViewHover.gameObject.SetActive(true);
            tribleAtkCardViewHover.transform.position = position;
        }
        else if (type == 7)
        {
            stokeTheFalmesCardViewHover.gameObject.SetActive(true);
            stokeTheFalmesCardViewHover.transform.position = position;
        }
        else if (type == 8)
        {
            meltdownRaysCardViewHover.gameObject.SetActive(true);
            meltdownRaysCardViewHover.transform.position = position;
        }
        else if (type == 9)
        {
            dischargeBoltCardViewHover.gameObject.SetActive(true);
            dischargeBoltCardViewHover.transform.position = position;
        }
        else if (type == 10)
        {
            kineticSlugCardViewHover.gameObject.SetActive(true);
            kineticSlugCardViewHover.transform.position = position;
        }
        else if (type == 11) {
            hVRCardViewHover.gameObject.SetActive(true);
            hVRCardViewHover.transform.position = position;
        }
        else if (type == 12)
        {
            staticAegisCardViewHover.gameObject.SetActive(true);
            staticAegisCardViewHover.transform.position = position;
        }
        else if (type == 13)
        {
            kineticRecyclerCardViewHover.gameObject.SetActive(true);
            kineticRecyclerCardViewHover.transform.position = position;
        }
    }

    public void Hide() {
        atkCardViewHover.gameObject.SetActive(false);
        defCardViewHover.gameObject.SetActive(false);
        compoundCardViewHover.gameObject.SetActive(false);
        doubleAtkCardViewHover.gameObject.SetActive(false);
        unstableBlastCardViewHover.gameObject.SetActive(false);
        overchargedInsulationCardViewHover.gameObject.SetActive(false);
        tribleAtkCardViewHover.gameObject.SetActive(false);
        stokeTheFalmesCardViewHover.gameObject.SetActive(false);
        meltdownRaysCardViewHover.gameObject.SetActive(false);
        dischargeBoltCardViewHover.gameObject.SetActive(false);
        kineticSlugCardViewHover.gameObject.SetActive(false);
        hVRCardViewHover.gameObject.SetActive(false);
        staticAegisCardViewHover.gameObject.SetActive(false);
        kineticRecyclerCardViewHover.gameObject.SetActive(false);
    }
}
