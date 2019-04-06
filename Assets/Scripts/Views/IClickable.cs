#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       07/04/2019 02:06
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using System;
using UnityEngine.EventSystems;

public interface IClickable : IPointerClickHandler
{
    Action OnClicked { set; }
}