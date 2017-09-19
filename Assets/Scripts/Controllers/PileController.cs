#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 17:14

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class PileController : MonoBehaviour, ICardController
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

    public void AddCard(Card card)
    {
        Sprite sprite = SpriteManager.Instance.GetSprite(card);

        pileView.SetSprite(sprite);

        pile.AddCard(card);
        Debug.Log("Pile: " + pile);
    }

    public void Clean()
    {
        if (faceDownPile.activeInHierarchy)
        {
            faceDownPile.SetActive(false);
            //TODO: Show taken cards.
        }

        pileView.SetActive(false);
    }
}
