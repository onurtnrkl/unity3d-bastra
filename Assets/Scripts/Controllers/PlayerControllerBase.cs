#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       25/03/2019 18:34
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerControllerBase : MonoBehaviour
{
    protected Player player;
    protected PileController pileController;
    protected Text scoreText;
    protected Transform handGroup;

    public virtual void Initialize()
    {
        pileController = GameManager.Instance.PileController;
        handGroup = transform.GetChild(0);
        Transform scoreGroup = transform.GetChild(1);
        scoreText = scoreGroup.GetChild(1).GetComponent<Text>();
    }

    private void UpdateScore(int score)
    {
        player.Score = score;
        scoreText.text = score.ToString();
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

    protected virtual void PlayCard(Card card)
    {
        Hand hand = player.Hand;
        Pile pile = pileController.Pile;
        hand.RemoveCard(card);

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

    public virtual void OnRoundStart()
    {
        player.Hand = new Hand();
    }

    public abstract void PrintLog();

    public abstract void AddCard(Card card);
}