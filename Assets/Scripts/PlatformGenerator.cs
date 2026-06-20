using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> platformPrefabs; 
    public Transform playerTransform;        

    [Header("Generator Settings")]
    public float platformLength = 40.5f;   
    public int maxPlatformsOnScreen = 4;     
    
    private List<GameObject> activePlatforms = new List<GameObject>();
    private float nextSpawnZ = 0f;
    private int platformsPassed = 0;

    void Start()
    {
        for (int i = 0; i < maxPlatformsOnScreen; i++)
        {
            if (i == 0) 
            {
                SpawnPlatform(0);
            }
            else 
            {
                int randomIndex = Random.Range(0, platformPrefabs.Count);
                SpawnPlatform(randomIndex);
            }
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        int currentPlayerPlatformIndex = Mathf.FloorToInt(playerTransform.position.z / platformLength);

        if (currentPlayerPlatformIndex > platformsPassed)
        {
            int randomIndex = Random.Range(0, platformPrefabs.Count);
            SpawnPlatform(randomIndex);
            
            RemoveOldPlatform();
            
            platformsPassed = currentPlayerPlatformIndex;
        }
    }

    void SpawnPlatform(int index)
    {
        if (platformPrefabs == null || platformPrefabs.Count == 0) return;

        GameObject platform = Instantiate(platformPrefabs[index], transform);
        platform.transform.position = new Vector3(0, 0, nextSpawnZ);
        
        activePlatforms.Add(platform);
        nextSpawnZ += platformLength;
    }

    void RemoveOldPlatform()
    {
        if (activePlatforms.Count > 0)
        {
            Destroy(activePlatforms[0]);
            activePlatforms.RemoveAt(0);
        }
    }
}