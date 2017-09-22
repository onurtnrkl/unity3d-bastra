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
using UnityEngine.UI;

public sealed class ComputerController : MonoBehaviour, ICardController
{
    private PileController pileController;
    public ComputerHand Hand;
    private List<CardView> cardViews;
    private Dictionary<Card, int> viewIndex;
    private Text scoreText;

    public byte Score { get; private set; }

    [HideInInspector]
    public int CollectedCards;

    public void Init()
    {
        pileController = GameManager.Instance.PileController;

        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        Transform handGroup = transform.GetChild(0);
        Transform scoreGroup = transform.GetChild(1);

        scoreText = scoreGroup.GetChild(1).GetComponent<Text>();

        cardViews = new List<CardView>();
        viewIndex = new Dictionary<Card, int>();

        for (byte i = 0; i < 4; i++)
        {
            CardView cardView = Instantiate(cardPrefab, handGroup).AddComponent<CardView>();

            cardViews.Add(cardView);
        }
    }

    public void Restart()
    {
        Hand = new ComputerHand();

        CollectedCards = 0;

        for (byte i = 0; i < 4; i++)
        {
            cardViews[i].SetActive(false);
        }
    }

    public void AddCard(Card card)
    {
        int index = Hand.Count();
        CardView cardView = cardViews[index];

        cardView.OnEndMove = () => PlayCard(card);
        cardView.SetSprite(SpriteManager.Instance.GetSprite("Cover"));
        cardView.SetActive(true);

        Hand.AddCard(card);
        viewIndex.Add(card, index);
    }

    public void Play()
    {
        Card card;

        if (pileController.Pile.IsEmpty())
        {
            card = Hand.GetLowPointCard();
        }
        else
        {
            Card topCard = pileController.Pile.TopCard();
            card = Hand.GetBestCard(topCard);
        }

        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        Vector2 position = GameManager.Instance.PileController.PileView.transform.position;
        int index = viewIndex[card];

        cardViews[index].SetSprite(sprite);
        cardViews[index].MoveTo(position);
        viewIndex.Remove(card);
    }

    private void PlayCard(Card card)
    {
        Hand.RemoveCard(card);
        Debug.Log("Computer Played: " + card);

        if (pileController.Pile.CanCollected(card))
        {
            CollectedCards += pileController.Pile.Count();

            byte collectScore = pileController.Collect(card);

            AddScore(collectScore);
        }
        else
        {
            pileController.AddCard(card);
        }

        GameManager.Instance.PlayerTurn = true;
        GameManager.Instance.EndTurn();
    }

    public void AddScore(byte score)
    {
        Score += score;
        scoreText.text = Score.ToString();
    }

    public void ResetScore()
    {
        Score = 0;
        scoreText.text = Score.ToString();
    }

    public void PrintLog()
    {
        Debug.Log("Computer Hand: " + Hand);
    }
}
