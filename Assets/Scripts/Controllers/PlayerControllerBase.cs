#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       25/03/2019 18:34
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    protected Player player;
    protected PileController pileController;
    protected PlayerView playerView;

    public virtual void Initialize()
    {
        pileController = GameManager.Instance.PileController;
    }

    private void UpdateScore(int score)
    {
        player.Score = score;
        //scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        int score = player.Score + amount;
        UpdateScore(score);
    }

    public void ResetScore()
    {
        UpdateScore(0);
    }

    //TODO: Some behaviours can move to PileController
    protected virtual void CollectCard(Card card)
    {
        Hand hand = player.Hand;
        HandView handView = playerView.HandView;
        Pile pile = pileController.Pile;
        hand.RemoveCard(card);
        handView.RemoveCard(card);

        if (pile.CanCollected(card))
        {
            player.CollectedCards += pile.Count;
            byte collectScore = pileController.Collect(card);
            AddScore(collectScore);
        }
        else
        {
            pileController.AddCard(card);
        }

        pile.IsBusy = false;
        GameManager.Instance.NextTurn();
    }

    public virtual void AddCard(Card card)
    {
        player.Hand.AddCard(card);
    }

    public virtual void OnRoundStart()
    {
        playerView.HandView.Clear();
        player.Hand = new Hand();
    }

    public abstract void PrintLog();
}