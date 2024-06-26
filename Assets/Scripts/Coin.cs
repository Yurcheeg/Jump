using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int money;
    public void AddMoney(int value)
    {
        money+=value;
        Debug.Log(money);
    }
    public void MoneyCheck(int cost)
    {
        if(money-cost<0)
        {
            Debug.Log("not enough money");
        }
        else
        {
            RemoveMoney(cost);
        }
    }
    void RemoveMoney(int cost)
    {
        money -= cost;
    }
}
