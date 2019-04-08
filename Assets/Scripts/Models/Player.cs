#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       08/04/2019 18:50
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

public class Player : PlayerBase
{
    public bool CanPlay;

    public Player() : base()
    {
        CanPlay = false;
    }
}