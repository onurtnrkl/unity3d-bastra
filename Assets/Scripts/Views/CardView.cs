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

[RequireComponent(typeof(Image))]
public class CardView : MonoBehaviour
{
    public Action OnEndMove
    {
        set
        {
            onEndMove = () => SetActive(false);
            onEndMove += value;       
        }
    }

    private Image image;
    private LayoutElement layoutElement;
    private Vector2 targetPosition;
    private bool isMoving;
    private Action onEndMove;

    private const float speed = 10;

    private void Awake()
    {
        image = GetComponent<Image>();
        layoutElement = GetComponent<LayoutElement>();
        onEndMove = () => SetActive(false);
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
                if (onEndMove != null)
                {
                    onEndMove();
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
