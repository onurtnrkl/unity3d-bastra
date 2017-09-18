#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 17:14

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public class PileController : MonoBehaviour
{
    private Pile pile;
    private CardView pileView;
    private CardView firstPileView;

    private void Awake()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        pileView = Instantiate(cardPrefab, transform).GetComponent<CardView>();
        firstPileView = Instantiate(cardPrefab, transform).GetComponent<CardView>();
    }

    public void AddCard()
    {
        Card card = new Card(Suit.Clubs, Rank.A);
        Sprite sprite = SpriteManager.Instance.GetSprite(card.ToString());

        pileView.SetSprite(sprite);
    }
}
