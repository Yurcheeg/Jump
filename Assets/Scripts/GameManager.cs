using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Coin.money = PlayerPrefs.GetInt("money", 0);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveSystem();
        }
        
    }
    private void OnApplicationQuit()
    {
        SaveSystem();
    }
    private void SaveSystem()
    {
        PlayerPrefs.SetInt("money", Coin.money);
        PlayerPrefs.Save();
    }
}
