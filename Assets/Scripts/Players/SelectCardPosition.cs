using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardPosition : MonoBehaviour
{

    // 選択されたカードの位置を調節する
    public void SetCard(Card card)
    {
        card.transform.SetParent(transform);
        card.transform.localPosition = Vector3.zero;
    }
}
