using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2END : MonoBehaviour

{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.LoadScene("ENDING");
    }
 
}
