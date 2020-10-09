﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] PlayerHand hand;// 手札を整列する
    [SerializeField] SelectCardPosition selectCardPosition;

    Card selectCard; // 選択したカード
    void Start()
    {
        SetupHand();
    }

    // 手札の用意：カードの生成
    void SetupHand()
    {
        List<Card> cards = new List<Card>();
        for (int i=0; i<8; i++)
        {
            Card card = CardGenerater.instance.Spawn(i);
            card.ClickAction = SelectCard;
            cards.Add(card);
        }
        hand.SetHandCards(cards);
    }

    // カードをクリックしたら、中央におく
    public void SelectCard(Card card)
    {
        if (selectCard != null)
        {
            hand.Add(selectCard);
        }

        selectCard = card; // 新しく選択カードを設定
        selectCardPosition.SetCard(card);
        hand.Remove(card);
    }

    // 決定ボタンを押したら、GameMasterに通知する
    public void SubmitCard()
    {
    }

}
