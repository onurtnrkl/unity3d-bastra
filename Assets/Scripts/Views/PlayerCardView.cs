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

public sealed class PlayerCardView : CardView, IClickable
{
    public Action OnClicked { private get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClicked != null)
        {
            OnClicked();
        }
    }
}
