using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GroundCheck _groundCheck;

    [SerializeField] private JumpBoostCheck _jumpBoost;
    [SerializeField] private Animator _animator;


    void Update()
    {
        UpdateMovementAnimaton();
        UpdateJumpingAnimation();
    }

    private void UpdateMovementAnimaton()
    {
        bool IsRunning = _playerController.MoveValue.sqrMagnitude > 0.01f;

        _animator.SetBool("IsRunning", IsRunning);



    }

    private void UpdateJumpingAnimation()
    {
      
        _animator.SetBool("IsJumping", !_groundCheck.isGround);
    }
}



