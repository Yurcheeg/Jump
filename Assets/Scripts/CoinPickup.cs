using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : Coin
{
    public GameObject coinObject;
    public Coin coin;   
    public BoxCollider2D boxCollider;
    public void CoinPick(Collider2D collider)
    {
        Destroy(collider.gameObject);
        coin.AddMoney(1);
    }
}
