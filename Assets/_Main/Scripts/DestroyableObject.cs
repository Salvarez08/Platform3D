using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    private ObjectSpawner spawner;

    void Start()
    {
        spawner = FindFirstObjectByType<ObjectSpawner>();
    }

    void OnDestroy()
    {
        
        if (spawner != null && gameObject.scene.isLoaded)
        {
            spawner.RespawnObject();
        }
    }
}
