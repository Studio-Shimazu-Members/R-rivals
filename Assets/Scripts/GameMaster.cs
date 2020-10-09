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

    [SerializeField] Player[] players;
    [SerializeField] AIInput ai;

    private void Start()
    {
        foreach (Player player in players)
        {
            player.OnSubmitAction = OnSubmitCard;
        }

        CallSettingHand();

        ai.Action();
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
    }

    // 提出確認
    bool IsCompletedSubmit()
    {
        return true;
    }

    // 判定
    void Battle()
    {

    }

    // 場のカードを捨てる
    void NextSetting()
    {

    }
}
