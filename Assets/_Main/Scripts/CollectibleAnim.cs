using UnityEngine;

public class CollectibleAnim : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 spinDirection = new Vector3(0, 100, 0); 

    [Header("Bobbing Settings")]
    [SerializeField] private float speed = 2f;      
    [SerializeField] private float strength = 0.5f; 

    private Vector3 startPosition;

    void Start()
    {
        
        startPosition = transform.position;
    }


    void Update()
    {
        transform.Rotate(spinDirection * Time.deltaTime);

        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * strength;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
