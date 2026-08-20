using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    public bool isGround;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
