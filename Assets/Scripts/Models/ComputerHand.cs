#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       19/09/2017 17:08

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

public sealed class ComputerHand : Hand
{
    public ComputerHand() : base()
    {

    }

    //private bool IsRankExist(Card card)
    //{
    //    Rank rank = card.Rank;
    //    int length = cards.Count;

    //    for (int i = 0; i < length; i++)
    //    {
    //        if (rank == cards[i].Rank) return true;
    //    }

    //    return false;
    //}

    /// <summary>
    /// Ai selects best card from deck.
    /// </summary>
    /// <param name="card">Pile top card</param>
    /// <returns></returns>
    public Card GetBestCard(Card card)
    {
        Rank rank = card.Rank;
        int length = cards.Count;

        for (int i = 0; i < length; i++)
        {
            if (rank == cards[i].Rank) return cards[i];
        }

        return GetLowPointCard();
    }

    public Card GetLowPointCard()
    {
        int length = cards.Count;

        for (int i = 0; i < length; i++)
        {
            if (cards[i].GetScore() == 0) return cards[i];
        }

        for (int i = 0; i < length; i++)
        {
            if (cards[i].GetScore() == 1) return cards[i];
        }

        for (int i = 0; i < length; i++)
        {
            if (cards[i].GetScore() == 2) return cards[i];
        }

        return cards[0];
    }
}
