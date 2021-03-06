#region License
// ====================================================
// Product:    Bastra
// Developer:  Onur Tanrıkulu
// Date:       08/04/2019 01:43
// Copyright (c) 2019 Onur Tanrikulu. All rights reserved.
// ====================================================
#endregion

using UnityEngine;

public class PileView : MonoBehaviour, ITarget
{
    public CardView FirstPile { get; private set; }

    public CardView SecondPile { get; private set; }

    public Vector2 Position
    {
        get
        {
            return transform.position;
        }
    }

    private void Awake()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        FirstPile = Instantiate(cardPrefab, transform).AddComponent<CardView>();
        SecondPile = Instantiate(cardPrefab, transform).AddComponent<CardView>();
    }
}