#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       25/03/2019 18:34
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

public abstract class PlayerControllerBase
{
    protected PileController pileController;

    public Player Player { get; private set; }

    public PlayerBaseView PlayerView { get; private set; }

    public PlayerControllerBase(Player player, PlayerBaseView playerView)
    {
        pileController = GameManager.Instance.PileController;
        Player = player;
        PlayerView = playerView;
    }

    private void UpdateScore(int score)
    {
        Player.Score = score;
        PlayerView.ScoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        int score = Player.Score + amount;
        UpdateScore(score);
    }

    public void ResetScore()
    {
        UpdateScore(0);
    }

    //TODO: Some behaviours can move to PileController
    protected virtual void CollectCard(Card card)
    {
        Hand hand = Player.Hand;
        HandView handView = PlayerView.HandView;
        Pile pile = pileController.Pile;
        hand.RemoveCard(card);
        handView.RemoveCard(card);

        if (pile.CanCollected(card))
        {
            Player.CollectedCards += pile.Count;
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
        Player.Hand.AddCard(card);
    }

    public virtual void OnRoundStart()
    {
        PlayerView.HandView.Clear();
        Player.Hand = new Hand();
    }

    public abstract void PrintLog();
}