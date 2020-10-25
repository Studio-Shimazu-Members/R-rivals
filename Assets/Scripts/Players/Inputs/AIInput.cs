using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    // GameMasterから管理される
    // playerを管理する
    // カードを選択する
    // カードを提出する

    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void Action()
    {
        // ランダムにカードを選択
        player.RandomSelectCard();
        player.SubmitCard();
        
    }

}
