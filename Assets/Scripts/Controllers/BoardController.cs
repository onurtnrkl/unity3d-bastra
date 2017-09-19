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
    private GameObject firstPile;

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        pileView = Instantiate(cardPrefab, transform).AddComponent<CardView>();
        firstPile = Instantiate(cardPrefab, transform);

        Restart();
    }

    public void Restart()
    {
        pile = new Pile();

        firstPile.SetActive(true);
    }

    public void PlaceCard(Card card)
    {
        string name = card.ToString();
        Sprite sprite = SpriteManager.Instance.GetSprite(name);

        pileView.SetSprite(sprite);

        pile.AddCard(card);
        Debug.Log(pile);
    }

    public void CleanPile()
    {
        if (firstPile.activeInHierarchy)
        {
            firstPile.SetActive(false);
            //TODO: Show taken cards.
        }

        pileView.SetActive(false);
    }
}
