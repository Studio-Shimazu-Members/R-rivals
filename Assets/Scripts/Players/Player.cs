using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    [SerializeField] PlayerHand hand;// 手札を整列する
    [SerializeField] SelectCardPosition selectCardPosition;

    Card selectCard; // 選択したカード

    public UnityAction OnSubmitAction;

    // 手札の用意：カードの生成
    public void SetupHand()
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
        // GameMasterの関数を実行できれば提出したことを知らせることができる
        OnSubmitAction.Invoke();
    }

}
