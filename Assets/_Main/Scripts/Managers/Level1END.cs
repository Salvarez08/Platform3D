using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1END : MonoBehaviour

{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.LoadScene("LEVEL 2");
    }
 
}
