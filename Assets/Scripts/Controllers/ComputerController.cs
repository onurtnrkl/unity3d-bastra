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

public sealed class ComputerController : PlayerControllerBase
{
    private List<CardView> cardViews;
    private Dictionary<Card, int> viewIndex;

    public Computer Computer { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        player = new Computer(pileController.Pile);
        Computer = (Computer)player;
        ResetScore();
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        cardViews = new List<CardView>();
        viewIndex = new Dictionary<Card, int>();

        for (byte i = 0; i < 4; i++)
        {
            CardView cardView = Instantiate(cardPrefab, handGroup).AddComponent<CardView>();
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
        int index = Computer.Hand.Count;
        CardView cardView = cardViews[index];

        cardView.OnEndMove = () => PlayCard(card);
        cardView.SetSprite(SpriteManager.Instance.GetSprite("Cover"));
        cardView.SetActive(true);

        Computer.Hand.AddCard(card);
        viewIndex.Add(card, index);
    }

    public void Play()
    {
        pileController.Pile.IsBusy = true;
        Card card = Computer.FindBestCard();
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        Vector2 position = GameManager.Instance.PileController.PileView.transform.position;
        int index = viewIndex[card];

        cardViews[index].SetSprite(sprite);
        cardViews[index].MoveTo(position);
        viewIndex.Remove(card);
    }

    public override void PrintLog()
    {
        Debug.Log("Computer Hand: " + Computer.Hand);
    }

    protected override void PlayCard(Card card)
    {
        base.PlayCard(card);
        Debug.Log("Computer Played: " + card);
    }
}
