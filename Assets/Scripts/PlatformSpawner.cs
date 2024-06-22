using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 100;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public List<BoxCollider2D> boxCollider2Ds = new List<BoxCollider2D>();
    void Start()
    {
        Vector3 spawnPosition = new();
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab,spawnPosition, Quaternion.identity);
        }
        foreach (BoxCollider2D bc in boxCollider2Ds) { 
            bc.size = new Vector3(levelWidth, spawnPosition.y * 100000);
        }
        
    }
}
