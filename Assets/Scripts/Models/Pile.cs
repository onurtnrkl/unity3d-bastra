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
    public bool IsBusy { get; set; }

    public Pile() : base()
    {
        IsBusy = false;
    }

    //public Card[] TakeCards()
    //{
    //    Card[] takenCards = cards.ToArray();
    //    cards.Clear();

    //    return takenCards;
    //}

    public void Clear()
    {
        cards.Clear();
    }

    public Card TopCard()
    {
        return cards[Count - 1];
    }

    public bool IsEmpty()
    {
        if (cards.Count == 0) return true;
        else return false;
    }

    public bool IsBastra(Card card)
    {
        if (Count == 1)
        {
            if (TopCard().Rank == card.Rank)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanCollected(Card card)
    {
        if (!IsEmpty())
        {
            if (card.Rank == Rank.J) return true;
            else if (card.Rank == TopCard().Rank) return true;
            else return false;
        }
        else
        {
            return false;
        }

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
