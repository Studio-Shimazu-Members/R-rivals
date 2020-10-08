using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerater : MonoBehaviour
{
    [SerializeField] Card cardPrefab;
    // Cardの生成：Prefabを生成すればいい

    private void Start()
    {
        for (int i=0; i<8; i++)
        {
            Spawn(i);
        }
    }

    public void Spawn(int number)
    {
        Card card = Instantiate(cardPrefab);
        card.Init(number);
    }
}
