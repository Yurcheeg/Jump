using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform coinManager;
    public AudioSource coinSFX;
    public void CoinSpawner(Vector3 spawnPosition)
    {
        spawnPosition.y += 1;
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity,coinManager);
    }
}
