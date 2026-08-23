using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GroundCheck _groundCheck;

    [SerializeField] private JumpBoost _jumpBoost;
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



        bool IsJumping = _playerController.isJump;



        if ((IsJumping == true) && (_groundCheck.isGround == false))
        {
            _animator.SetBool("IsJumping", true);

        }    
        if ((IsJumping == false) && (_groundCheck.isGround == true))
        {
                _animator.SetBool("IsJumping", false);

        }

        if ((IsJumping == false) && (_jumpBoost.isJumpBoost == true))
        {
            _animator.SetBool("IsJumping", true);

        }

    }
    }



