#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       07/04/2019 02:01
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using System;

public interface IMovable
{
    Action OnMoveEnded { set; }
    void MoveTo(ITarget target);
}