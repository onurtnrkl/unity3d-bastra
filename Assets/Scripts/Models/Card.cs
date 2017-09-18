#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 00:37

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

public struct Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        string suit = Suit.ToString();
        string rank = Rank.ToString();

        return string.Format("{0}_{1}", suit, rank);
    }
}
