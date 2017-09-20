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
    public static GameManager Instance { get; private set; }

    public PlayerController PlayerController;
    public ComputerController ComputerController;
    public PileController PileController;

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
        PlayerController.Init();
        ComputerController.Init();
    }

    public void Restart()
    {
        round = 0;
        PlayerController.ResetScore();
        ComputerController.ResetScore();
    }

    public void StartRound()
    {
        deck = new Deck();
        round++;
        Move = 1;

        PileController.Restart();
        PlayerController.Restart();
        ComputerController.Restart();

        for (byte i = 0; i < 4; i++) PileController.AddCard(deck.DrawCard());

        DealCards();
    }

    private void EndRound()
    {
        //Collect remaining cards from last turn;
        ComputerController.CollectedCards += PileController.Pile.Count();
        ComputerController.AddScore(PileController.Pile.GetScore());

        if (PlayerController.Score >= 101 || ComputerController.Score >= 101)
        {
            menuManager.EndGame(PlayerController.Score, ComputerController.Score);
        }
        else
        {
            if (ComputerController.CollectedCards > PlayerController.CollectedCards)
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

    public void DealCards()
    {
        if (deck.Count() == 0)
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

            Debug.LogFormat("Remaining Cards: {0}", deck.Count());
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
