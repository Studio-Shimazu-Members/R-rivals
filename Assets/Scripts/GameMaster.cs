using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    // ゲームの進行を管理
    //・手札の準備
    //・両Playerがカードを提出したか確認
    //・カードの勝敗を判定
    //・カードの削除
    //・次の対戦

    // TODO:
    // ・カードを捨てる
    // ・次のゲームの準備をする

    [SerializeField] Player[] players;
    [SerializeField] AIInput ai;

    private void Start()
    {
        foreach (Player player in players)
        {
            player.OnSubmitAction = OnSubmitCard;
        }

        CallSettingHand();

        //ai.Action(); // 先に出すならここに書く
    }

    // 手札を準備させる
    void CallSettingHand()
    {
        foreach (Player player in players)
        {
            player.SetupHand();
        }
    }

    // Playerから提出通知を受ける

    public void OnSubmitCard()
    {
        Debug.Log("Playerがカードを提出");
        // 両者がカードを出していれば、判定
        if (IsCompletedSubmit())
        {
            StartCoroutine(Battle());
        }
        else
        {
            ai.Action();
        }
    }

    // 提出確認
    bool IsCompletedSubmit()
    {
        if (players[0].submitted && players[1].submitted)
        {
            return true;
        }
        return false;
    }

    // 判定
    IEnumerator Battle()
    {
        Debug.Log("判定");
        int player1Card = players[0].SubmittedCard.number;
        int player2Card = players[1].SubmittedCard.number;
        if (player1Card > player2Card)
        {
            Debug.Log("勝ち");
        }
        else if(player1Card < player2Card)
        {
            Debug.Log("負け");
        }
        else
        {
            Debug.Log("引き分け");
        }
        //Invoke("NextSetting",1f);
        yield return new WaitForSeconds(1f);
        NextSetting();
    }

    // 場のカードを捨てる
    void NextSetting()
    {
        foreach(Player player in players)
        {
            player.DestroySubmitCard();
        }
        // players[0].DestroySubmitCard();
        // players[1].DestroySubmitCard();
    }
}
