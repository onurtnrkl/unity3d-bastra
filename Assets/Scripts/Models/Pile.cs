#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 20:03

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using System.Text;

public sealed class Pile
{
    private List<Card> cards;
    public bool IsFirst;//is first pile? if is set active facedown card on pile area.

    public Pile()
    {
        cards = new List<Card>();
        IsFirst = true;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public Card[] TakeCards()
    {
        Card[] takenCards = cards.ToArray();
        cards.Clear();

        return takenCards;
    }

    public byte GetScore()
    {
        byte score = 0;

        byte length = (byte)cards.Count;

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

        byte length = (byte)cards.Count;

        for (byte i = 0; i < length; i++)
        {
            Card card = cards[i];
            string name = card.ToString();

            stringBuilder.Append(name);

            if(i < length - 1) stringBuilder.Append(" | ");
        }

        return stringBuilder.ToString();
    }
}
