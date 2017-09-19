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
    private CardView firstPileView;

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        pileView = Instantiate(cardPrefab, transform).GetComponent<CardView>();
        firstPileView = Instantiate(cardPrefab, transform).GetComponent<CardView>();

        Restart();
    }

    public void Restart()
    {
        pile = new Pile();

        firstPileView.SetActive(true);
    }

    public void PlaceCard(Card card)
    {
        string name = card.ToString();
        Sprite sprite = SpriteManager.Instance.GetSprite(name);

        pileView.SetSprite(sprite);

        pile.AddCard(card);
        Debug.Log(pile);
    }

    public void TakeCards()
    {
        if (pile.IsFirst)
        {
            firstPileView.SetActive(false);
            //TODO: Show taken cards.
        }
    }
}
