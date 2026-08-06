using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;

    public Vector2 moveValue { get; private set; }
    public bool isJump { get; private set; }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        isJump = jumpAction.IsPressed();
    }
}
