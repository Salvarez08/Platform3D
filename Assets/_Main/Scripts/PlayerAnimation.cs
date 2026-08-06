using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator animator;
  
    private static readonly int IsRunningParameter = 
        Animator.StringToHash("IsRunning");
    void Update()
    {
        UpdateMovementAnimation();
    }
    private void UpdateMovementAnimation()

    {
        bool isRunning = playerController.moveValue.sqrMagnitude > 0.01f;
        animator.SetBool(IsRunningParameter, isRunning);
    }
}
