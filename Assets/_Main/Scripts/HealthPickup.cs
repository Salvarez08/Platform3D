using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IncreaseHealth(healAmount);
            Destroy(gameObject);
        }
    }
}