#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 20:03

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Linq;

public sealed class Pile : CardCollection
{
    public Pile() : base()
    {
        
    }

    public Card[] TakeCards()
    {
        Card[] takenCards = cards.ToArray();
        cards.Clear();

        return takenCards;
    }

    public Card TopCard()
    {
        return cards.Last();
    }

    public byte GetScore()
    {
        byte score = 0;

        int length = cards.Count;

        for (byte i = 0; i < length; i++)
        {
            Card card = cards[i];
            score += card.GetScore();
        }

        return score;
    }
}
