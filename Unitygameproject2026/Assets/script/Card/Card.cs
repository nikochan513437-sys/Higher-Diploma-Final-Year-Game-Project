using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject wrapper;

    [SerializeField] private LayerMask dropLayer;

    public bool isDragging = false;

    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;
    public int cardType;

    private void OnMouseEnter()
    {
        if (!PlayerCanHover())
            return;
         wrapper.SetActive(false);
         Vector3 pos = new(transform.position.x, -2, 0);
         CardViewHoverSystem.instance.Show(pos, cardType);
        
    }

    public bool PlayerCanHover() {
        if (isDragging) return false;
        return true;
    }

    private void OnMouseExit()
    {
        if (!PlayerCanHover())
            return;
        CardViewHoverSystem.instance.Hide();
         wrapper.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!PlayerCanHover())
            return;
        isDragging = true;
        wrapper.SetActive(true);
        CardViewHoverSystem.instance.Hide();
        CardSystem.instance.dropArea.SetActive(true);
        dragStartPosition = transform.position;
        dragStartRotation = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void OnMouseDrag()
    {
        if (PlayerCanHover())
            return;
        transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);
    }

    private void OnMouseUp()
    {
        if (PlayerCanHover())
            return;
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, dropLayer))
        {
            if (cardType == 0)
            {
                PlayAtkCard();
            }
            else if (cardType == 1)
            {
                PlayDefCard();
            }
        }
        else {
            transform.position = dragStartPosition;
            transform.rotation = dragStartRotation;
        }
        isDragging = false;
        CardSystem.instance.dropArea.SetActive(false);
    }

    private void PlayAtkCard() 
    {
        ActiveCard.CardActiveList.Enqueue(0);
        CardSystem.instance.cards.Remove(gameObject);
        Destroy(gameObject);
        //...
    }

    private void PlayDefCard()
    {
        ActiveCard.CardActiveList.Enqueue(1);
        CardSystem.instance.cards.Remove(gameObject);
        Destroy(gameObject);
        //...
    }
}
