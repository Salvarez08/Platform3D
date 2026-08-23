using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GroundCheck _groundCheck;
    [SerializeField] private JumpBoostCheck _jumpBoost;
    [SerializeField] private Rigidbody _rb;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        Move();
        Jump();
        RotateTowardsMovementDirection();
    }

    private void Move()
    {
        Vector2 playerInputs = _playerController.MoveValue;

        _rb.linearVelocity = new Vector3(playerInputs.x * speed, _rb.linearVelocity.y, playerInputs.y * speed);
    }

    private void Jump()
    {
        if (_playerController.isJump && _groundCheck.isGround)
        {
            _rb.AddForce(new Vector3(_rb.linearVelocity.x, jumpForce, _rb.linearVelocity.z), ForceMode.Impulse);
            _playerController.isJump = false;
        }

        if (_playerController.isJump && _jumpBoost.isJumpBoost)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);
            _rb.AddForce(new Vector3(_rb.linearVelocity.x, jumpForce * 5, _rb.linearVelocity.z), ForceMode.Impulse);

            _playerController.isJump = false;
            _jumpBoost.isJumpBoost = false;
        }
    }



    private void RotateTowardsMovementDirection()
    {
        Vector2 playerImputs = _playerController.MoveValue;

        if (playerImputs.sqrMagnitude <= 0.01f)
        {
            return;

        }

        Vector3 direction = new Vector3(playerImputs.x, 0f, playerImputs.y);

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        _rb.MoveRotation(targetRotation);
    }
}