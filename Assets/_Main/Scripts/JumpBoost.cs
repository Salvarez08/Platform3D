using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public bool isJumpBoost;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpBoost"))
        {
            isJumpBoost = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JumpBoost"))
        {
            isJumpBoost = false;
            Destroy(other.gameObject);
        }
    }
}
