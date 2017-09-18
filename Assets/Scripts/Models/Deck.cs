#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 12:34

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Random = System.Random;

public sealed class Deck
{
    private List<Card> cards;

    /// <summary>
    /// Creates standart 52 card deck
    /// https://en.wikipedia.org/wiki/Standard_52-card_deck
    /// </summary>
    public Deck()
    {
        cards = new List<Card>();

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
                Debug.LogFormat("{0} added to deck.", card);
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

        for (byte i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i]);
        }
    }

    public Card DrawCard()
    {
        Card card = cards.Last();
        cards.Remove(card);
        Debug.LogFormat("Drawn Card: {0}", card);
        Debug.LogFormat("Remaining Cards: {0}", cards.Count);

        return card;
    }
}