using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    //役割/機能
    //・Playerの手札を管理する
    //・最初のカード生成もここでやってしまう
    List<Card> cards = new List<Card>();

    public void Setup(List<Card> cards)
    {
        this.cards = cards;
        RefreshCardPosition();
    }

    void RefreshCardPosition()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            card.transform.SetParent(transform, false);
            float index = (i - cards.Count / 2f);
            card.transform.localPosition = new Vector3(index * 1.2f, 0, 0);
        }
    }

    public Card RandomSelect()
    {
        int r = Random.Range(0, cards.Count);
        Card card = cards[r];
        cards.Remove(card);
        RefreshCardPosition();
        return card;
    }

    public void Remove(Card card)
    {
        cards.Remove(card);
        RefreshCardPosition();
    }
    public void Add(Card card)
    {
        cards.Add(card);
        cards.Sort((a, b) => a.number - b.number);
        RefreshCardPosition();
    }

}
