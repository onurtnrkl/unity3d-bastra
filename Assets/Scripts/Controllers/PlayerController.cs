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
    public PlayerController(Player player, PlayerView playerView) : base(player, playerView)
    {

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
        if (GameManager.Instance.IsPlayerTurn && !pileController.Pile.IsBusy)
        {
            CardView cardView = PlayerView.HandView[card];
            pileController.Pile.IsBusy = true;
            Vector2 position = pileController.PileView.transform.position;
            cardView.MoveTo(position);
        }
    }

    public override void PrintLog()
    {
        Debug.Log("Player Hand: " + Player.Hand);
    }
}
