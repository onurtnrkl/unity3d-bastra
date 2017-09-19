#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 20:03

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Linq;
using System.Text;

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

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        int length = cards.Count - 1;

        if (length == 0) stringBuilder.Append("Empty");

        for (int i = length; i > -1; i--)
        {
            Card card = cards[i];
            string name = card.ToString();

            stringBuilder.Append(name);

            if (i > 0) stringBuilder.Append(" | ");
        }

        return stringBuilder.ToString();
    }
}
