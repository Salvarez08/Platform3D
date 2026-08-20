using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Rigidbody rb;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        Move();
        Jump();
        RotateTowardsMovementDirection();
    }

    private void Move()
    {
        Vector2 playerInputs = playerController.MoveValue;

        rb.linearVelocity = new Vector3(playerInputs.x * speed, rb.linearVelocity.y, playerInputs.y * speed);
    }

    private void Jump()
    {
        if (playerController.isJump && groundCheck.isGround)
        {
 

            rb.AddForce(new Vector3 (rb.linearVelocity.x, jumpForce, rb.linearVelocity.z), ForceMode.Impulse);
            playerController.isJump = false;


        }
     

    }



    private void RotateTowardsMovementDirection()
    {
        Vector2 playerImputs = playerController.MoveValue;

        if (playerImputs.sqrMagnitude <= 0.01f)
        {
            return;

        }

        Vector3 direction = new Vector3(playerImputs.x, 0f, playerImputs.y);

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        rb.MoveRotation(targetRotation);
    }
}