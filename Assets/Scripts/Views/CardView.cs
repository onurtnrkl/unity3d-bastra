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
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class CardView : MonoBehaviour, IMovable
{
    private Image image;
    private LayoutElement layoutElement;
    private Vector2 targetPosition;
    private bool isMoving;
    private Action onMoveEnded;

    private const float speed = 10;

    public Action OnMoveEnded
    {
        set
        {
            onMoveEnded = () => SetActive(false);
            onMoveEnded += value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
        layoutElement = GetComponent<LayoutElement>();
        onMoveEnded = () => SetActive(false);
    }

    private void Update()
    {
        if (isMoving)
        {
            float totalSpeed = speed * Time.deltaTime;
            Vector2 lerp = Vector2.Lerp(transform.position, targetPosition, totalSpeed);
            float distance = Vector2.Distance(transform.position, targetPosition);

            transform.position = lerp;

            if (distance < 1f)
            {
                if (onMoveEnded != null)
                {
                    onMoveEnded();
                }

                isMoving = false;
            }
        }
    }

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetActive(bool value)
    {
        layoutElement.ignoreLayout = !value;
        gameObject.SetActive(value);
    }

    public void MoveTo(Vector2 position)
    {
        layoutElement.ignoreLayout = true;
        targetPosition = position;
        isMoving = true;
    }
}
