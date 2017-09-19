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

    private Deck deck;
    private byte round;
    private byte move;

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

        PileController.Init();
        PlayerController.Init();
        ComputerController.Init();

        StartRound();
    }

    private void StartRound()
    {
        deck = new Deck();
        round++;
        move = 0;

        
        DealCards();
    }

    private void DealCards()
    {
        for (byte i = 0; i < 4; i++)
        {
            PileController.AddCard(deck.DrawCard());
            PlayerController.AddCard(deck.DrawCard());
            ComputerController.AddCard(deck.DrawCard());
        }
    }

    public void PrintLog()
    {
        Debug.LogFormat("Round: {0} | Move: {1}", round, move);
        PileController.PrintLog();
        PlayerController.PrintLog();
        ComputerController.PrintLog();
    }
}
