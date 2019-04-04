#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 14:53

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class ComputerController : PlayerControllerBase
{
    public Computer Computer { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        player = new Computer(pileController.Pile);
        Computer = (Computer)player;
        playerView.HandView.Initialize();
    }

    public override void AddCard(Card card)
    {
        base.AddCard(card);
        ComputerHandView handView = (ComputerHandView)playerView.HandView;
        handView.AddCard(card, () => CollectCard(card));
    }

    public void Play()
    {
        pileController.Pile.IsBusy = true;
        Card card = Computer.FindBestCard();
        CardView cardView = playerView.HandView[card];
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        Vector2 position = GameManager.Instance.PileController.PileView.transform.position;
        cardView.SetSprite(sprite);
        cardView.MoveTo(position);
    }

    public override void PrintLog()
    {
        Debug.Log("Computer Hand: " + Computer.Hand);
    }

    protected override void CollectCard(Card card)
    {
        base.CollectCard(card);
        Debug.Log("Computer Played: " + card);
    }
}
