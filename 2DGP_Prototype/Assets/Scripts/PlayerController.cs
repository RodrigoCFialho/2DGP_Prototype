using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    private Animator myAnimator = null;

    [SerializeField]
    private float speed = 3f;
    private Vector2 moveInput;

    private CustomInput customInput;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        customInput = CustomInputManager.Instance.GetCustomInput();
        customInput.Player.Movement.Enable();

        customInput.Player.Movement.performed += InputMovementPerformedHandler;
        customInput.Player.Movement.canceled += InputMovementCancelledHandler;
    }

    private void OnDestroy()
    {
        customInput.Player.Movement.performed -= InputMovementPerformedHandler;
        customInput.Player.Movement.canceled -= InputMovementCancelledHandler;
    }

    private void InputMovementCancelledHandler(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void InputMovementPerformedHandler(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
   
    private void FixedUpdate()
    {
        // movement
        myRigidbody2D.velocity = moveInput * speed;

        // animations
        myAnimator.SetFloat("VerticalSpeed", myRigidbody2D.velocity.y);
        myAnimator.SetFloat("HorizontalSpeed", myRigidbody2D.velocity.x);
    }
}
