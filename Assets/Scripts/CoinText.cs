using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : Coin
{
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        text.text = Coin.money.ToString();
    }
}
