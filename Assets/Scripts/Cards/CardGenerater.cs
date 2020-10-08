using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerater : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    // Cardの生成：Prefabを生成すればいい

    // どこからでも使えるようにする
    public static CardGenerater instance;
    private void Awake()
    {
        instance = this;
    }

    public Card Spawn(int number)
    {
        Card card = Instantiate(cardPrefab);
        card.Init(number);
        return card;
    }
}
