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
    public PlayerController PlayerController;
    public ComputerController ComputerController;
    public PileController PileController;

    public static GameManager Instance { get; private set; }

    public bool IsPlayerTurn { get; private set; }

    [SerializeField]
    private MenuManager menuManager;

    private Deck deck;
    private byte round;

    [HideInInspector]
    public byte Move;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            Init();
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

    private void Init()
    {
        DontDestroyOnLoad(gameObject);

        menuManager.Init();
        PileController.Init();
        PlayerController.Initialize();
        ComputerController.Initialize();
    }

    public void StartRound()
    {
        deck = new Deck();
        round++;
        Move = 1;
        IsPlayerTurn = true;

        PileController.Restart();
        PlayerController.Restart();
        ComputerController.Restart();

        for (byte i = 0; i < 4; i++) PileController.AddCard(deck.DrawCard());

        DealCards();
    }

    private void EndRound()
    {
        //Collects remaining cards from last turn;
        Computer computer = ComputerController.Computer;
        Player player = PlayerController.Player;

        computer.CollectedCards += PileController.Pile.Count;
        ComputerController.AddScore(PileController.Pile.GetScore());

        if (player.Score >= 101 || computer.Score >= 101)
        {
            menuManager.EndGame(player.Score, computer.Score);
        }
        else
        {
            if (computer.CollectedCards > player.CollectedCards)
            {
                ComputerController.AddScore(3);
            }
            else
            {
                PlayerController.AddScore(3);
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

            if (PlayerController.Player.Hand.Count == 0)
            {
                DealCards();
            }
        }
        else
        {
            Debug.Log("Computer Turn");

            if (ComputerController.Computer.Hand.Count == 0)
            {
                DealCards();
            }

            ComputerController.Play();
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
                PlayerController.AddCard(deck.DrawCard());
                ComputerController.AddCard(deck.DrawCard());
            }

            Debug.LogFormat("Remaining Cards: {0}", deck.Count);
        }
    }

    public void PrintLog()
    {
        Debug.LogFormat("Round: {0} | Move: {1}", round, Move);
        PileController.PrintLog();
        PlayerController.PrintLog();
        ComputerController.PrintLog();
    }
}
