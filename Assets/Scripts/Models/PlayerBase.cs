#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       28/03/2019 12:34

Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

public class PlayerBase
{
    public Hand Hand { get; set; }

    public int Score { get; set; }

    public int CollectedCards { get; set; }

    public PlayerBase()
    {
        Hand = new Hand();
        CollectedCards = 0;
        Score = 0;
    }
}