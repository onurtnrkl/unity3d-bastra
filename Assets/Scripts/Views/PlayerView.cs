#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       31/03/2019 00:02
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

public class PlayerView : PlayerBaseView
{
    protected override void Awake()
    {
        base.Awake();
        HandView = GetComponentInChildren<PlayerHandView>();
    }
}