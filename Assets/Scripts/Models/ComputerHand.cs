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

    public bool IsRankExist(Card card)
    {
        Rank rank = card.Rank;
        int length = cards.Count;

        for (int i = 0; i < length; i++)
        {
            if (rank == cards[i].Rank) return true;
        }

        return false;
    }
}
