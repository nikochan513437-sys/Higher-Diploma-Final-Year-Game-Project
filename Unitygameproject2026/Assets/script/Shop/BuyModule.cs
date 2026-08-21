using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuyModule : MonoBehaviour
{
    public ModuleInventory inventory;
    public Module cannon2;
    public GameObject price;
    public Vector3 transPoint;

    void OnMouseDown()
    {
        //if (Coin.coin >= 120)
        {
            Coin.ReduceCoin(550);
            Debug.Log("give module");
            inventory.moduleList[0] = cannon2;
            ModuleManage.UpdateInventory();
            ModuleBackpack.UpdateBackpack();
            Destroy(price);
            transform.DOMove(transPoint, 0.5f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
