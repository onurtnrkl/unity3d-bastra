#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 00:37

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

public sealed class Card
{
    public Rank Rank { get; private set; }
    public Suit Suit { get; private set; }

    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }
}
