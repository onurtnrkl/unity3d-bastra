using System;
using UnityEngine;

public class ComputerHandView : HandView
{
    protected override CardView AddCardComponent(GameObject cardObject)
    {
        return cardObject.AddComponent<CardView>();
    }

    public void AddCard(Card card, Action onMoveEnded)
    {
        CardView cardView = pool.GetObject();
        cardView.OnEndMove = onMoveEnded;
        cardView.SetSprite(SpriteManager.Instance.GetSprite("Cover"));
        cardView.SetActive(true);
        cardViews.Add(card, cardView);
    }
}
