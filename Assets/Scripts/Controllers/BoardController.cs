#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 17:14

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class BoardController : MonoBehaviour, IController
{
    private Pile pile;
    private CardView pileView;
    private GameObject faceDownPile;

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        pileView = Instantiate(cardPrefab, transform).AddComponent<CardView>();
        faceDownPile = Instantiate(cardPrefab, transform);

        Restart();
    }

    public void Restart()
    {
        pile = new Pile();

        faceDownPile.SetActive(true);
    }

    public void PlaceCard(Card card)
    {
        Sprite sprite = SpriteManager.Instance.GetSprite(card);

        pileView.SetSprite(sprite);
        pile.AddCard(card);
        Debug.Log(pile);
    }

    public void CleanPile()
    {
        if (faceDownPile.activeInHierarchy)
        {
            faceDownPile.SetActive(false);
            //TODO: Show taken cards.
        }

        pileView.SetActive(false);
    }
}
