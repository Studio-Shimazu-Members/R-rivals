using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    public int number;
    // TODO：役職
    public TMP_Text text;
    public UnityAction<Card> ClickAction;


    public void Init(int number)
    {
        this.number = number;
        text.text = number.ToString();
    }

    public void OnClickThis()
    {
        Debug.Log("Cardが押されたよ！");
        // PlayerのSelectCardを実行したい
        ClickAction.Invoke(this);
    }
}
