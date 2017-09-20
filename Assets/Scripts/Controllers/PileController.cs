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
    public Pile Pile { get; private set; }

    private CardView pileView;
    private GameObject faceDownPile;
    private AudioClip bastraClip;
    private AudioClip collectClip;

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        bastraClip = Resources.Load<AudioClip>("Sounds/Bastra");
        collectClip = Resources.Load<AudioClip>("Sounds/Collect");
        pileView = Instantiate(cardPrefab, transform).AddComponent<CardView>();
        faceDownPile = Instantiate(cardPrefab, transform);
    }

    public void Restart()
    {
        Pile = new Pile();

        faceDownPile.SetActive(true);
    }

    public void AddCard(Card card)
    {
        Sprite sprite = SpriteManager.Instance.GetSprite(card);

        pileView.SetSprite(sprite);

        Pile.AddCard(card);

        if (!pileView.gameObject.activeInHierarchy) pileView.SetActive(true);
    }

    public byte Collect(Card card)
    {
        byte score;

        if (Pile.IsBastra(card))
        {
            if (card.Rank == Rank.J)
            {
                score = 20;
            }
            else
            {
                score = 10;
            }

            SoundManager.Instance.PlaySingleClip(bastraClip);
            Debug.Log(card.Rank + " Bastra!");
        }
        else
        {
            Pile.AddCard(card);
            score = Pile.GetScore();

            SoundManager.Instance.PlaySingleClip(collectClip);
            Debug.Log(Pile + " Collected!");
        }

        if (faceDownPile.activeInHierarchy)
        {
            faceDownPile.SetActive(false);
            //TODO: Show taken cards.
        }

        pileView.SetActive(false);
        Pile.Clear();

        return score;
    }

    public void PrintLog()
    {
        Debug.Log("Pile: " + Pile);
    }
}
