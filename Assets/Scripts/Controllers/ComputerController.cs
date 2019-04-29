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
    private Computer computer;

    public ComputerController(Computer computer, ComputerView computerView, PileController pileController) : base(computer, computerView, pileController)
    {
        this.computer = computer;
    }

    public override void AddCard(Card card)
    {
        base.AddCard(card);
        ComputerHandView handView = (ComputerHandView)PlayerView.HandView;
        handView.AddCard(card, () => CollectCard(card));
    }

    public void Play()
    {
        pileController.Pile.IsBusy = true;
        Card card = computer.FindBestCard();
        CardView cardView = PlayerView.HandView[card];
        Sprite sprite = SpriteManager.Instance.GetSprite(card);
        cardView.SetSprite(sprite);
        cardView.MoveTo(pileController.PileView);
    }

    public override void MakeTurn()
    {
        Debug.Log("Computer Turn");
        Play();
    }

    public override void PrintLog()
    {
        Debug.Log("Computer Hand: " + computer.Hand);
    }

    protected override void CollectCard(Card card)
    {
        base.CollectCard(card);
        Debug.Log("Computer Played: " + card);
    }
}
