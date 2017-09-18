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

    [SerializeField]
    private Transform canvas;

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

        Deck deck = new Deck();
        deck.DrawCard();
        deck.DrawCard();
    }
}
