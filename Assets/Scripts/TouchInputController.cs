using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputController : MonoBehaviour
{
    private TouchControls inputActions;

    public bool isTouching;

    public Vector2 touchPosition;

    private void OnEnable()
    {
       SetupInputActions();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void SetupInputActions()
    {
        inputActions = new TouchControls();

        inputActions.Touch.IsTouching.started += ctx => StartTouch(ctx);
        inputActions.Touch.IsTouching.canceled += ctx => EndTouch(ctx);

        inputActions.Enable();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Started: " + inputActions.Touch.TouchPosition.ReadValue<Vector2>());
        isTouching = true;
        touchPosition = inputActions.Touch.TouchPosition.ReadValue<Vector2>();
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch Ended");
        isTouching = false;
        touchPosition = Vector2.zero;
    }
}
