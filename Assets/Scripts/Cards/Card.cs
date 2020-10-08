using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class Card : MonoBehaviour
{
    //役割/機能
    //・数字を持つ
    //・効果を持つ
    //・名前を持つ
    //・クリックされたら、Playerの選択とする
    //・どちらのカードか

    public UnityAction<Card> ClickAction;

    public enum Type
    {
        Spy
    }

    public int number;
    public Type type;


    Player.PlayerID owner;

    // UI
    public TextMeshPro textMeshPro;

    public void Setting(int number, Player.PlayerID owner)
    {
        this.number = number;
        type = (Type)number;
        textMeshPro.text = number.ToString();
        this.owner = owner;
    }

    public void OnClickThis()
    {
        ClickAction.Invoke(this);
    }
}
