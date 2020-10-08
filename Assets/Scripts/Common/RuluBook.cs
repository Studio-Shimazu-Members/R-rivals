using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RuluBook : MonoBehaviour
{
    public enum Result
    {
        Draw,
        Player0Win,
        Player0Win2,
        Player1Win,
        Player1Win2,
    }

    //役割
    // ルールを管理
    // 2枚のカードでどちらが勝ったのかをGameMasterに通知する

    public Result Battle(Player player0, Player player1)
    {
        if (player0.selectedCard.number > player1.selectedCard.number)
        {
            return Result.Player0Win;

        }
        else if (player0.selectedCard.number < player1.selectedCard.number)
        {
            return Result.Player1Win;
        }

        return Result.Draw;
    }
}
