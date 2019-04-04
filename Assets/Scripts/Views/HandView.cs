#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       31/03/2019 00:19
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using System.Collections.Generic;
using UnityEngine;

public abstract class HandView : MonoBehaviour
{
    protected Dictionary<Card, CardView> cardViews;
    protected ObjectPool<CardView> pool;

    public CardView this[Card card]
    {
        get
        {
            return cardViews[card];
        }
    }

    public void Initialize()
    {
        cardViews = new Dictionary<Card, CardView>();
        pool = new ObjectPool<CardView>(4);
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        for (byte i = 0; i < 4; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab, transform);
            CardView cardView = AddCardComponent(cardObject);
            pool.AddObject(cardView);
        }
    }

    protected abstract CardView AddCardComponent(GameObject cardObject);

    public void Clear()
    {
        foreach(Card card in cardViews.Keys)
        {
            RemoveCard(card);
        }
    }

    public void RemoveCard(Card card)
    {
        CardView cardView = cardViews[card];
        pool.AddObject(cardView);
        cardView.SetActive(false);
        cardViews.Remove(card);
    }
}