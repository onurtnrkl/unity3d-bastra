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

public sealed class PlayerController : PlayerControllerBase
{
    private List<PlayerCardView> cardViews;

    public Player Player
    {
        get
        {
            return player;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        player = new Player();
        ResetScore();
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        cardViews = new List<PlayerCardView>();

        for (byte i = 0; i < 4; i++)
        {
            PlayerCardView cardView = Instantiate(cardPrefab, handGroup).AddComponent<PlayerCardView>();

            cardViews.Add(cardView);
        }
    }

    public override void OnRoundStart()
    {
        base.OnRoundStart();

        for (byte i = 0; i < 4; i++)
        {
            cardViews[i].SetActive(false);
        }
    }

    public override void AddCard(Card card)
    {
        int index = player.Hand.Count;
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        PlayerCardView cardView = cardViews[index];

        cardView.OnEndMove = () => PlayCard(card);
        cardView.OnClick = () => OnClick(cardView);
        cardView.SetSprite(sprite);
        cardView.SetActive(true);

        player.Hand.AddCard(card);
    }

    protected override void PlayCard(Card card)
    {
        base.PlayCard(card);
        Debug.Log("Player Played: " + card);
    }

    private void OnClick(CardView cardView)
    {
        if(GameManager.Instance.IsPlayerTurn && !pileController.Pile.IsBusy)
        {
            pileController.Pile.IsBusy = true;
            Vector2 position = GameManager.Instance.PileController.PileView.transform.position;
            cardView.MoveTo(position);
        }
    }

    public override void PrintLog()
    {
        Debug.Log("Player Hand: " + player.Hand);
    }
}
