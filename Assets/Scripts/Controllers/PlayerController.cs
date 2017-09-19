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

public sealed class PlayerController : MonoBehaviour, ICardController
{
    private PileController pileController;
    private ComputerController computerController;
    private Hand hand;
    private List<PlayerCardView> cardViews;

    public void Init()
    {
        pileController = GameManager.Instance.PileController;
        computerController = GameManager.Instance.ComputerController;

        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        Transform handGroup = transform.GetChild(0);

        cardViews = new List<PlayerCardView>();

        for (byte i = 0; i < 4; i++)
        {
            PlayerCardView cardView = Instantiate(cardPrefab, handGroup).AddComponent<PlayerCardView>();

            cardViews.Add(cardView);
        }

        Restart();
    }

    public void Restart()
    {
        hand = new Hand();

        for (byte i = 0; i < 4; i++)
        {
            cardViews[i].SetActive(false);
        }
    }

    public void AddCard(Card card)
    {
        int index = hand.Count();
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        PlayerCardView cardView = cardViews[index];

        cardView.OnClick = ()=> OnPlaceCard(card, index);
        cardView.SetSprite(sprite);
        cardView.SetActive(true);

        hand.AddCard(card);
    }

    private void OnPlaceCard(Card card, int index)
    {
        hand.RemoveCard(card);
        cardViews[index].SetActive(false);

        if (pileController.Pile.IsEmpty())
        {
            pileController.AddCard(card);
        }
        else
        {
            Card topCard = pileController.Pile.TopCard();

            if (card.Rank == topCard.Rank || card.Rank == Rank.J)
            {
                Debug.Log("Pisti");
                pileController.TakeCards();
            }
            else
            {
                pileController.AddCard(card);
            }
        }

        computerController.Play();

        if (hand.Count() == 0) GameManager.Instance.DealCards();
    }

    public void PrintLog()
    {
        Debug.Log("Player Hand: " + hand);
    }
}
