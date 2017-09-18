#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 20:03

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;

public sealed class Pile
{
    private List<Card> cards;
    private bool isFirst;//is first pile? if is set active facedown card on pile area.

    public Pile()
    {
        cards = new List<Card>();
        isFirst = true;
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
}
