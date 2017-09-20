#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 12:34

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Linq;
using UnityEngine;

using Random = System.Random;

public sealed class Deck : CardCollection
{
    /// <summary>
    /// Creates standart 52 card deck
    /// https://en.wikipedia.org/wiki/Standard_52-card_deck
    /// </summary>
    public Deck() : base()
    {
        AddCards();
        Shuffle();
    }

    /// <summary>
    /// Adds all cards to deck.
    /// </summary>
    private void AddCards()
    {
        for (byte rank = 0; rank < 13; rank++)
        {
            for (byte suit = 0; suit < 4; suit++)
            {
                Card card = new Card((Suit)suit, (Rank)rank);
                cards.Add(card);
            }
        }
    }

    /// <summary>
    /// Mixes cards in deck.
    /// </summary>
    private void Shuffle()
    {
        Random random = new Random();
        cards = cards.OrderBy(x => random.Next()).ToList();

        //for (byte i = 0; i < cards.Count; i++)
        //{
        //    Debug.Log(cards[i]);
        //}
    }

    /// <summary>
    /// Draws top card from deck.
    /// </summary>
    /// <returns></returns>
    public Card DrawCard()
    {
        Card card = cards.Last();
        cards.Remove(card);
        //Debug.LogFormat("Drawn Card: {0}", card);
        //Debug.LogFormat("Remaining Cards: {0}", cards.Count);

        return card;
    }
}
