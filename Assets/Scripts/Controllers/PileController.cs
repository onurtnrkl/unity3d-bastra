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

        pile = new Pile();
    }

    public void PlaceCard(Card card)
    {
        string name = card.ToString();
        Sprite sprite = SpriteManager.Instance.GetSprite(name);

        pileView.SetSprite(sprite);

        pile.AddCard(card);
        byte score = pile.GetScore();
        //Debug.Log("Pile Score: " + score);
        Debug.Log(pile);
    }
}
