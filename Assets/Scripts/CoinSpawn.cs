using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;

    public void CoinSpawner(Vector3 spawnPosition)
    {
        spawnPosition.y += 1;
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
