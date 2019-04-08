#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       19/09/2017 14:59

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Text;

public abstract class CardCollection : ICollection<Card>
{
    protected List<Card> cards;

    public int Count
    {
        get
        {
            return cards.Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return false;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return Count == 0;
        }
    }

    public CardCollection()
    {
        cards = new List<Card>();
    }

    public Card this[int index]
    {
        get
        {
            return cards[index];
        }
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public bool Remove(Card card)
    {
        return cards.Remove(card);
    }

    public void Clear()
    {
        cards.Clear();
    }

    public bool Contains(Card card)
    {
        return cards.Contains(card);
    }

    public void CopyTo(Card[] cards, int index)
    {
        cards.CopyTo(cards, index);
    }

    public IEnumerator<Card> GetEnumerator()
    {
        return cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return cards.GetEnumerator();
    }

    public override string ToString()
    {
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
