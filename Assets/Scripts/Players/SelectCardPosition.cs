using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardPosition : MonoBehaviour
{
    // Playerが選択したカードを、所定の場所（自分と同じ場所）におく

    public void SetCard(Card card)
    {
        // Cardの親を自分にする
        card.transform.SetParent(this.transform);
        card.transform.localPosition = Vector3.zero;
    }
}
