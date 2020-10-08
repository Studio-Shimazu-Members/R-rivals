using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    // AIの役割
    // ・player1を操る
    // ・自動でカードを選ぶ
    // ・場に設定する


    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void Action()
    {
        player.RandomSelectCard();
    }

    public void OnSubmitButton()
    {
        player.SubmitCard();
    }
}
