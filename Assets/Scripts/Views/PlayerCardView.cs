#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 19:38

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System;
using UnityEngine.EventSystems;

public sealed class PlayerCardView : CardView, IPointerDownHandler
{
    public Action OnClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnClick != null)
        {
            OnClick();
        }
    }
}
