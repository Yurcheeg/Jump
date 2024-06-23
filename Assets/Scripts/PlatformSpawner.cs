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


    [SerializeField] private List<BoxCollider2D> boxCollider2Ds = new List<BoxCollider2D>();

    private List<GameObject> platforms;
    Vector3 spawnPosition = new();
    void Start()
    {
        platforms = new List<GameObject>();
        spawnPosition = new Vector3();
        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject newPlatform = Instantiate(platformPrefab,spawnPosition, Quaternion.identity);
            platforms.Add(newPlatform);
        }
        foreach (BoxCollider2D border in boxCollider2Ds) { 
            border.size = new Vector3(levelWidth, spawnPosition.y * 100000);
        }

    }
    private void Update()
    {
        for (int i = platforms.Count - 1; i >= 0; i--)
        {
            if (platforms[i].transform.position.y < Camera.main.transform.position.y - 8)
            {
                ReplacePlatform(platforms[i]);
            }
        }
    }
    void ReplacePlatform(GameObject platform)
    {
        platforms.Remove(platform);
        Destroy(platform);

        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        platforms.Add(newPlatform);
    }
}
