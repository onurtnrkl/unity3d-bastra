#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 15:03

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour, IPointerDownHandler
{
    public event Action OnClick;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        OnClick += () => Debug.Log(gameObject.name + " was clicked.");
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick();
    }
}
