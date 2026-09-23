using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifeTime = 5f;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.ReduceHealth(damage);
        }

        Destroy(gameObject);
    }
}
