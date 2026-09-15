using UnityEngine;

public class MusicNote : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int noteNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.getNote(noteNumber);

            gameObject.SetActive(false);
        }
    }
}
