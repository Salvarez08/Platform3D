using UnityEngine;

public class JumpBoostCheck : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    public bool isJumpBoost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpBoost"))
        {
            isJumpBoost = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("JumpBoost"))
        {
            isJumpBoost = false;
        }
    }
}
