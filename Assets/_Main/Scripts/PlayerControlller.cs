using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControlller : MonoBehaviour
{
    
    InputAction moveAction;
    InputAction jumpAction;


    private void Start()
    {
      
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        

        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool jumpValue = jumpAction.IsPressed();

        Debug.Log("Me Muevo" + moveValue);
        Debug.Log("Salto" + jumpValue);

        if (jumpAction.IsPressed())
        {
            Debug.Log("Jump action is pressed");
        }
    }
}
