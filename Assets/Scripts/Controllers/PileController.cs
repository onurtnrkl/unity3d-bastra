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
    public CardView PileView;

    private CardView faceDownPileView;
    private AudioClip bastraClip;
    private AudioClip collectClip;

    public Pile Pile { get; private set; }

    public void Init()
    {
        GameObject cardPrefab = Resources.Load<GameObject>("Prefabs/Card");

        bastraClip = Resources.Load<AudioClip>("Sounds/Bastra");
        collectClip = Resources.Load<AudioClip>("Sounds/Collect");
        PileView = Instantiate(cardPrefab, transform).AddComponent<CardView>();
        faceDownPileView = Instantiate(cardPrefab, transform).AddComponent<CardView>();
    }

    public void Restart()
    {
        Pile = new Pile();
        faceDownPileView.SetActive(true);
    }

    //TODO: Add PlayCard Method.

    public void AddCard(Card card)
    {
        Sprite sprite = SpriteManager.Instance.GetSprite(card);

        PileView.SetSprite(sprite);

        Pile.AddCard(card);

        if (!PileView.gameObject.activeInHierarchy)
        {
            PileView.SetActive(true);
        } 
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
            Debug.Log("Bastra!");
        }
        else
        {
            Pile.AddCard(card);
            score = Pile.GetScore();

            SoundManager.Instance.PlaySingleClip(collectClip);
        }

        if (faceDownPileView.gameObject.activeInHierarchy)
        {
            Sprite sprite = SpriteManager.Instance.GetSprite("Clean");

            faceDownPileView.gameObject.SetActive(false);
            PileView.SetSprite(sprite);

            //Set Clean Texture to card.
            //faceDownPileView.MoveTo(target.position);
            //TODO: Show taken cards.
        }
        else
        {
            PileView.gameObject.SetActive(false);
        }

        Debug.Log("Collected cards: " + Pile);
        Pile.Clear();

        return score;
    }

    public void PrintLog()
    {
        Debug.Log("Pile: " + Pile);
    }
}
