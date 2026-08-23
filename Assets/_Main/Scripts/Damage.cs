using UnityEngine;

public class Damage : MonoBehaviour
{
   
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int _damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.ReduceHealth(_damage);
        }

    }

}
