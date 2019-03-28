#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       29/03/2019 17:52

Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

public sealed class Computer : Player
{
    private Pile pile;

    public Computer(Pile pile) : base()
    {
        this.pile = pile;
    }

    /// <summary>
    /// Ai finds best card from deck.
    /// </summary>
    public Card FindBestCard()
    {
        if (!pile.IsEmpty())
        {
            Rank rank = pile.TopCard().Rank;
            int length = Hand.Count;

            for (int i = 0; i < length; i++)
            {
                Card card = Hand[i];

                if (rank == card.Rank)
                {
                    return card;
                }
            }
        }

        return FindLowCard();
    }

    private Card FindLowCard()
    {
        Card lowCard = Hand[0];
        int length = Hand.Count;

        for (int i = 0; i < length; i++)
        {
            Card card = Hand[i];

            if (card.GetScore() < lowCard.GetScore())
            {
                lowCard = card;
            }
        }

        return lowCard;
    }
}