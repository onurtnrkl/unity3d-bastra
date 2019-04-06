using System;
using UnityEngine;

public class PlayerHandView : HandView
{
    protected override CardView AddCardComponent(GameObject cardObject)
    {
        return cardObject.AddComponent<PlayerCardView>();
    }

    public void AddCard(Card card, Action onMoveEnded, Action onClicked)
    {
        PlayerCardView cardView = (PlayerCardView)pool.GetObject();
        cardView.OnMoveEnded = onMoveEnded;
        cardView.OnClicked = onClicked;
        cardView.SetSprite(SpriteManager.Instance.GetSprite(card));
        cardView.SetActive(true);
        cardViews.Add(card, cardView);
    }
}
