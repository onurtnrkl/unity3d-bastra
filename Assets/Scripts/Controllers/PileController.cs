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
    public Pile pile { get; private set; }
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

        if (!pileView.gameObject.activeInHierarchy) pileView.SetActive(true);
    }

    public byte Collect(Card card)
    {
        byte score;

        if (pile.IsBastra(card))
        {
            if (card.Rank == Rank.J)
            {
                score = 20;
            }
            else
            {
                score = 10;
            }

            Debug.Log(card.Rank + " Bastra!");
        }
        else
        {
            pile.AddCard(card);
            score = pile.GetScore();

            Debug.Log(pile + " Collected!");
        }

        if (faceDownPile.activeInHierarchy)
        {
            faceDownPile.SetActive(false);
            //TODO: Show taken cards.
        }

        pileView.SetActive(false);
        pile.Clear();

        return score;
    }

    public void PrintLog()
    {
        Debug.Log("Pile: " + pile);
    }
}
