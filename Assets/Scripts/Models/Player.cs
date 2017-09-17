#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 00:47

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;

public sealed class Player
{
    public List<Card> Hand;

    public Player()
    {
        Hand = new List<Card>();
    }
}
