using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int damage = 10;
    [SerializeField] private float damageInterval = 1f; // segundos entre cada golpe

    private float damageCooldown = 0f;

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
    }

    void Update()
    {
        if (damageCooldown > 0f)
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && damageCooldown <= 0f)
        {
            gameManager.ReduceHealth(damage);
            damageCooldown = damageInterval;
        }
    }
}