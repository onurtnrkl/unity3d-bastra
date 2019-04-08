#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       17/09/2017 23:51

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    private ComputerController computerController;
    private PileController pileController;
    private PlayerControllerBase turnPlayerController;
    private MenuManager menuManager;
    private Deck deck;
    private byte round;

    public byte Move { get; set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PrintLog();
        }
    }

    private void Initialize()
    {
        Transform canvas = FindObjectOfType<Canvas>().transform;

        Pile pile = new Pile();
        PileView pileView = Instantiate(Resources.Load<PileView>("Prefabs/Pile"), canvas);
        pileController = new PileController(pile, pileView);

        Player player = new Player();
        PlayerView playerView = Instantiate(Resources.Load<PlayerView>("Prefabs/Player"), canvas);
        playerController = new PlayerController(player, playerView, pileController);

        Computer computer = new Computer(pile);
        ComputerView computerView = Instantiate(Resources.Load<ComputerView>("Prefabs/Computer"), canvas);
        computerController = new ComputerController(computer, computerView, pileController);

        menuManager = Instantiate(Resources.Load<MenuManager>("Prefabs/Menu"), canvas);
    }

    public void StartRound()
    {
        deck = new Deck();
        round++;
        Move = 1;
        turnPlayerController = playerController;
        turnPlayerController.MakeTurn();

        pileController.OnRoundStart();
        playerController.OnRoundStart();
        computerController.OnRoundStart();

        for (byte i = 0; i < 4; i++) pileController.AddCard(deck.DrawCard());

        DealCards();
    }

    private void EndRound()
    {
        //Collects remaining cards from last turn;
        PlayerBase computer = computerController.Player;
        PlayerBase player = playerController.Player;

        computer.CollectedCards += pileController.Pile.Count;
        computerController.AddScore(pileController.Pile.GetScore());

        if (player.Score >= 101 || computer.Score >= 101)
        {
            menuManager.EndGame(player.Score, computer.Score);
        }
        else
        {
            if (computer.CollectedCards > player.CollectedCards)
            {
                computerController.AddScore(3);
            }
            else
            {
                playerController.AddScore(3);
            }

            StartRound();
        }
    }

    private void NextPlayer()
    {
        if (turnPlayerController == playerController)
        {
            turnPlayerController = computerController;
        }
        else
        {
            turnPlayerController = playerController;
        }
    }

    public void NextTurn()
    {
        NextPlayer();
        Move++;

        if (turnPlayerController.Player.Hand.IsEmpty)
        {
            DealCards();
        }

        turnPlayerController.MakeTurn();
    }

    public void DealCards()
    {
        if (deck.Count == 0)
        {
            EndRound();
        }
        else
        {
            for (byte i = 0; i < 4; i++)
            {
                playerController.AddCard(deck.DrawCard());
                computerController.AddCard(deck.DrawCard());
            }

            Debug.LogFormat("Remaining Cards: {0}", deck.Count);
        }
    }

    public void PrintLog()
    {
        Debug.LogFormat("Round: {0} | Move: {1}", round, Move);
        pileController.PrintLog();
        playerController.PrintLog();
        computerController.PrintLog();
    }
}
