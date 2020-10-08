using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerater : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    public static CardGenerater instance;
    public void Awake()
    {
        instance = this;
    }

    public Card Spawn(int number, Player.PlayerID owner)
    {
        Card card = Instantiate(cardPrefab);
        card.Setting(number, owner);
        return card;
    }
}