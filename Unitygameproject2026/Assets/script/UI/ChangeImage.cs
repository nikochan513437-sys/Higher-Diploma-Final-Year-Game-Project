using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image image;

    public Sprite openImage;
    public Sprite closeImage;

    public void ChangeOpenButton() {
        if (image.sprite == closeImage)
            image.sprite = openImage;
    }

    public void ChangeCloseButton()
    {
        image.sprite = closeImage;
    }
}
