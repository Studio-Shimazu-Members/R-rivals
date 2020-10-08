using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    // Playerの基本的な処理を行う
    // ・GameMasterに管理される
    // ・PlayerInputとAIInputに管理される
    // ・手札と場に出すカードを保持している
    // ・


    public enum PlayerID
    {
        Player0,
        Player1,
    }

    [SerializeField] PlayerID playerID;

    [SerializeField] SelectCardPosition selectCardPosition;
    [SerializeField] PlayerHand hand;



    public Card selectedCard;

    // ・UnityActionを使って通知を送る
    public UnityAction OnSubmitAction;
    public bool submited;

    public UnityAction SpyAction;
    public bool isSpyEffecting; // 先に表で出さなければいけない
    public bool isGeneralEffecting; // 先に表で出さなければいけない


    //機能/役割
    //・カードの選択
    //・カードの決定


    public void SetupHand()
    {
        List<Card> cards = new List<Card>();
        // カードを生成
        for (int i = 0; i < 8; i++)
        {
            Card card = CardGenerater.instance.Spawn(i, playerID);
            cards.Add(card);
        }
        foreach (Card card in cards)
        {
            card.ClickAction = SelectCard;
        }
        // 手札に渡す
        hand.Setup(cards);
    }

    //選択
    public void SelectCard(Card card)
    {
        if (selectedCard != null)
        {
            hand.Add(selectedCard);
        }
        selectedCard = card;
        selectCardPosition.SetCard(card);
        hand.Remove(card);
    }

    //時間切れの場合はランダムに選択する：GameMaterから使われる
    public void RandomSelectCard()
    {
        // 手札の中から１つ選択する
        Card card = hand.RandomSelect();
        SelectCard(card);
        SubmitCard();
    }


    // 決定
    public void SubmitCard()
    {
        submited = true;
        OnSubmitAction.Invoke();
    }

    public void ReceiveSpyEffect()
    {
        isSpyEffecting = true;
    }
    public void ReceiveGeneralEffect()
    {
        isGeneralEffecting = true;
    }

    public void DeleteCard()
    {
        Destroy(selectedCard.gameObject);
    }
}

