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
    private MenuManager menuManager;
    private Deck deck;
    private byte round;

    public PileController PileController { get; private set; }

    public bool IsPlayerTurn { get; private set; }

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
        PileController = new PileController(pile, pileView);

        Player player = new Player();
        PlayerView playerView = Instantiate(Resources.Load<PlayerView>("Prefabs/Player"), canvas);
        playerController = new PlayerController(player, playerView);

        Computer computer = new Computer(pile);
        ComputerView computerView = Instantiate(Resources.Load<ComputerView>("Prefabs/Computer"), canvas);
        computerController = new ComputerController(computer, computerView);

        menuManager = Instantiate(Resources.Load<MenuManager>("Prefabs/Menu"), canvas);
    }

    public void StartRound()
    {
        deck = new Deck();
        round++;
        Move = 1;
        IsPlayerTurn = true;

        PileController.OnRoundStart();
        playerController.OnRoundStart();
        computerController.OnRoundStart();

        for (byte i = 0; i < 4; i++) PileController.AddCard(deck.DrawCard());

        DealCards();
    }

    private void EndRound()
    {
        //Collects remaining cards from last turn;
        Player computer = computerController.Player;
        Player player = playerController.Player;

        computer.CollectedCards += PileController.Pile.Count;
        computerController.AddScore(PileController.Pile.GetScore());

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
                computerController.AddScore(3);
            }

            StartRound();
        }
    }

    public void NextTurn()
    {
        IsPlayerTurn = !IsPlayerTurn;
        Move++;

        if (IsPlayerTurn)
        {
            Debug.Log("Player Turn");

            if (playerController.Player.Hand.Count == 0)
            {
                DealCards();
            }
        }
        else
        {
            Debug.Log("Computer Turn");

            if (computerController.Player.Hand.Count == 0)
            {
                DealCards();
            }

            computerController.Play();
        }
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
        PileController.PrintLog();
        playerController.PrintLog();
        computerController.PrintLog();
    }
}
