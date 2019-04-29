#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 14:53

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class PlayerController : PlayerControllerBase
{
    private Player player;

    public PlayerController(Player player, PlayerView playerView, PileController pileController) : base(player, playerView, pileController)
    {
        this.player = player;
    }

    public override void AddCard(Card card)
    {
        base.AddCard(card);
        PlayerHandView handView = (PlayerHandView)PlayerView.HandView;
        handView.AddCard(card, () => CollectCard(card), () => OnClicked(card));
    }

    protected override void CollectCard(Card card)
    {
        base.CollectCard(card);
        Debug.Log("Player Played: " + card);
    }

    private void OnClicked(Card card)
    {
        if (player.CanPlay)
        {
            player.CanPlay = false;
            CardView cardView = PlayerView.HandView[card];
            cardView.MoveTo(pileController.PileView);
        }
    }

    public override void MakeTurn()
    {
        player.CanPlay = true;
        Debug.Log("Player Turn");
    }

    public override void PrintLog()
    {
        Debug.Log("Player Hand: " + Player.Hand);
    }
}
