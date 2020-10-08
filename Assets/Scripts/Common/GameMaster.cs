using System.Collections;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //進行管理
    //・PlayerとruluBookを管理
    //・AIに命令する

    //やること
    //・Playerが選択した場合に通知を受ける
    //・どちらも出したか確認する
    //・RuluBookをみてどちらが勝ったか判断する
    //・ゲームの進行

    [SerializeField] Player[] players;
    RuluBook ruluBook;

    [SerializeField] AIInput AIInput;

    private void Awake()
    {
        ruluBook = GetComponent<RuluBook>();
    }

    private void Start()
    {
        // Playerが決定ボタンを押したら、通知を受けてSubmitを実行する
        foreach (Player player in players)
        {
            player.OnSubmitAction = OnPlayerSubmit;
        }

        foreach (Player player in players)
        {
            player.SetupHand();
        }

    }


    void OnPlayerSubmit()
    {
        // どちらも提出済みなら判定する
        if (IsSubmissionCompleted())
        {
            Battle(players[0], players[1]);
        }

        // CPUがまだ提出していないならランダムで提出させる
        if (players[1].submited == false)
        {
            AIInput.Action();
        }

    }

    bool IsSubmissionCompleted()
    {
        foreach (Player player in players)
        {
            if (player.submited == false)
            {
                return false;
            }
        }
        return true;
    }

    void Battle(Player player0, Player player1)
    {
        // ばのカードを捨てて
        RuluBook.Result result = ruluBook.Battle(player0, player1);
        Debug.Log(result);
        switch (result)
        {
            case RuluBook.Result.Draw:
                break;
            case RuluBook.Result.Player0Win:
                break;
            case RuluBook.Result.Player0Win2:
                break;
            case RuluBook.Result.Player1Win:
                break;
            case RuluBook.Result.Player1Win2:
                break;
        }
        StartCoroutine(CallNext());
    }

    IEnumerator CallNext()
    {
        yield return new WaitForSeconds(1f);
        foreach (Player player in players)
        {
            player.DeleteCard();
            player.submited = false;
        }
    }
}
