#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 14:53

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using UnityEngine;

public sealed class ComputerController : MonoBehaviour, ICardController
{
    private ComputerHand hand;
    private List<GameObject> cardViews;

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        Transform handGroup = transform.GetChild(0);

        cardViews = new List<GameObject>();

        for (byte i = 0; i < 4; i++)
        {
            GameObject cardView = Instantiate(cardPrefab, handGroup);

            cardViews.Add(cardView);
        }

        Restart();
    }

    public void Restart()
    {
        hand = new ComputerHand();

        for (byte i = 0; i < 4; i++)
        {
            cardViews[i].SetActive(false);
        }
    }

    public void AddCard(Card card)
    {
        int index = hand.Count();
        GameObject cardView = cardViews[index];

        cardView.SetActive(true);

        hand.AddCard(card);
    }

    public void PlayCard()
    {
        //TODO: Computer AI
    }

    public void PrintLog()
    {
        Debug.Log("Computer Hand: " + hand);
    }
}
