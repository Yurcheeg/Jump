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


    Vector3 spawnPosition = new();
    void Start()
    {
        
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab,spawnPosition, Quaternion.identity);
        }
        foreach (BoxCollider2D border in boxCollider2Ds) { 
            border.size = new Vector3(levelWidth, spawnPosition.y * 100000);
        }

        platformPrefab.gameObject.GetComponent<Ground>();
        if (platformPrefab == null)
        {
            Debug.Log("No platform found");
        }

    }
    private void Update()
    {
        if(platformPrefab.transform.position.y < Camera.main.transform.position.y + 5)
        {
            ReplacePlatform(platformPrefab);
        }
    }
    void ReplacePlatform(GameObject platform)
    {
        DestroyImmediate(platform,true);
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
