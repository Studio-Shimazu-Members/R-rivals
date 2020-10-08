using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        SetupHand();
    }

    // 手札の用意：カードの生成
    void SetupHand()
    {
        for (int i=0; i<8; i++)
        {
            Card card = CardGenerater.instance.Spawn(i);
            card.ClickAction = SelectCard;
        }
    }

    // カードをクリックしたら、中央におく
    public void SelectCard(Card card)
    {
        Debug.Log("SelectCard:"+card.number);
    }

    // 決定ボタンを押したら、GameMasterに通知する
    public void SubmitCard()
    {
    }

}
