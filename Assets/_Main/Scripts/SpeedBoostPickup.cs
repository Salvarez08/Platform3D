using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float boostDuration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.ActivateSpeedBoost(speedMultiplier, boostDuration);        }
    }
}