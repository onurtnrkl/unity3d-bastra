#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       19/09/2017 14:59

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using System.Text;

public abstract class CardCollection
{
    protected List<Card> cards;

    public CardCollection()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    public int Count()
    {
        return cards.Count;
    }

    public override string ToString()
    {
        //FIXME: Sometimes returns Empty.
        StringBuilder stringBuilder = new StringBuilder();

        int length = cards.Count - 1;

        if (length == -1) stringBuilder.Append("Empty");

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
