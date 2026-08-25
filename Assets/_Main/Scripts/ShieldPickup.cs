using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float shieldDuration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.ActivateShield(shieldDuration);
            Destroy(gameObject);
        }
    }
}
