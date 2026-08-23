using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private Animator animator;
 

    void Update()
    {
        UpdateMovementAnimaton();
        UpdateJumpingAnimation();
    }

    private void UpdateMovementAnimaton()
    {
        bool IsRunning = playerController.MoveValue.sqrMagnitude > 0.01f;

        animator.SetBool("IsRunning", IsRunning);



    }

    private void UpdateJumpingAnimation()
    {



        bool IsJumping = playerController.isJump;

      

        if ((IsJumping == true) && (groundCheck.isGround == false))
        {
            animator.SetBool("IsJumping", true);

        }
        if ((IsJumping == false) && (groundCheck.isGround == true))
        {
            animator.SetBool("IsJumping", false);
        }

            if (playerController.isJump == false && groundCheck.isGround == false)
            {
                animator.SetBool("IsRunning", false);

            }
    

    }
}


