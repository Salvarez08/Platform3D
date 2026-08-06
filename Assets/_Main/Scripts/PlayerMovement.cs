using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private PlayerController controller;
    private Rigidbody rb;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector2 input = controller.moveValue;

        rb.linearVelocity = new Vector3(
            input.x * speed,
            rb.linearVelocity.y,
            input.y * speed
        );
    }

    private void Jump()
    {
        if (controller.isJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
