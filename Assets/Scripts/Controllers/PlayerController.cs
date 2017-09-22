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

public sealed class PlayerController : MonoBehaviour, ICardController
{
    private PileController pileController;
    public Hand Hand;
    private List<PlayerCardView> cardViews;
    private Text scoreText;

    public byte Score { get; private set; }

    public int CollectedCards { get; private set; }

    public void Init()
    {
        pileController = GameManager.Instance.PileController;

        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        Transform handGroup = transform.GetChild(0);
        Transform scoreGroup = transform.GetChild(1);

        scoreText = scoreGroup.GetChild(1).GetComponent<Text>();

        cardViews = new List<PlayerCardView>();

        for (byte i = 0; i < 4; i++)
        {
            PlayerCardView cardView = Instantiate(cardPrefab, handGroup).AddComponent<PlayerCardView>();

            cardViews.Add(cardView);
        }
    }

    public void Restart()
    {
        Hand = new Hand();

        CollectedCards = 0;

        for (byte i = 0; i < 4; i++)
        {
            cardViews[i].SetActive(false);
        }
    }

    public void AddCard(Card card)
    {
        int index = Hand.Count();
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        PlayerCardView cardView = cardViews[index];

        cardView.OnEndMove = () => OnPlaceCard(card);
        cardView.OnClick = () => OnClick(card, cardView);
        cardView.SetSprite(sprite);
        cardView.SetActive(true);

        Hand.AddCard(card);
    }

    private void OnPlaceCard(Card card)
    {
        Hand.RemoveCard(card);
        Debug.Log("Player Played: " + card);

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

        GameManager.Instance.EndTurn();
    }

    private void OnClick(Card card, CardView cardView)
    {
        if(GameManager.Instance.PlayerTurn)
        {            
            GameManager.Instance.PlayerTurn = false;
            Vector2 position = GameManager.Instance.PileController.PileView.transform.position;
            cardView.MoveTo(position);
        }
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
        Debug.Log("Player Hand: " + Hand);
    }
}
