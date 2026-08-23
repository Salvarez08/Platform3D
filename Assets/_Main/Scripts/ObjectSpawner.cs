using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Vector3 spawnPosition;   
    public float respawnDelay = 5f; 

    
    public void RespawnObject()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }
}
