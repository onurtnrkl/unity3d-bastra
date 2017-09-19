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
    public BoardController BoardController;

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
        
    }

    private void Init()
    {
        DontDestroyOnLoad(gameObject);

        BoardController.Init();
        PlayerController.Init();

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
            BoardController.PlaceCard(deck.DrawCard());
            PlayerController.AddCard(deck.DrawCard());
            //TODO: Add player
        }
    }

    public void PrintLog()
    {
        //Round 1, Move 1
        //Pile_Cards = x | x | x | x
        //Player_Hand = = x | x | x | x
        //Computer_Hand = = x | x | x | x
    }
}
