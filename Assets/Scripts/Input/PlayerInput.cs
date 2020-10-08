using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    // 役割
    // ・player0を操る
    // ・ユーザの決定ボタンをplayer0に通知する

    Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void OnSubmitButton()
    {
        player.SubmitCard();
    }
}
