#region License
/*================================================================
Product:    Bastra
Developer:  Onur Tanrıkulu
Date:       18/09/2017 17:14

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using UnityEngine;

public sealed class PileController
{  
    private AudioClip bastraClip;
    private AudioClip collectClip;

    public Pile Pile { get; private set; }

    public PileView PileView { get; private set; }

    public PileController(Pile pile, PileView pileView)
    {
        Pile = pile;
        PileView = pileView;

        bastraClip = Resources.Load<AudioClip>("Sounds/Bastra");
        collectClip = Resources.Load<AudioClip>("Sounds/Collect");
    }

    public void OnRoundStart()
    {
        Pile.Clear();
        PileView.SecondPile.SetActive(true);
    }

    //TODO: Add PlayCard Method.

    public void AddCard(Card card)
    {
        Sprite sprite = SpriteManager.Instance.GetSprite(card);

        PileView.FirstPile.SetSprite(sprite);

        Pile.AddCard(card);

        if (!PileView.FirstPile.gameObject.activeInHierarchy)
        {
            PileView.FirstPile.SetActive(true);
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

        if (PileView.SecondPile.gameObject.activeInHierarchy)
        {
            Sprite sprite = SpriteManager.Instance.GetSprite("Clean");

            PileView.SecondPile.gameObject.SetActive(false);
            PileView.FirstPile.SetSprite(sprite);

            //Set Clean Texture to card.
            //faceDownPileView.MoveTo(target.position);
            //TODO: Show taken cards.
        }
        else
        {
            PileView.FirstPile.gameObject.SetActive(false);
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
