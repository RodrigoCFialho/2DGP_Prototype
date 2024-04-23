using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputSystem : MonoBehaviour
{
    private CustomInput customInput;

    private Vector2 moveInput;

    [SerializeField]
    private UnityEvent<Vector2> onEnableMovementEvent;

    [SerializeField]
    private UnityEvent onInteractEvent;

    [SerializeField]
    private UnityEvent onHitEvent;

    private void Start()
    {
        customInput = CustomInputManager.Instance.customInputsBindings;

        customInput.Player.Movement.performed += InputMovementPerformed;
        customInput.Player.Movement.canceled += InputMovementCancelled;

        customInput.Player.Interact.performed += InputInteractPerformed;

        customInput.Player.Hit.performed += InputHitPerformedHandler;
    }

    private void InputInteractPerformed(InputAction.CallbackContext context)
    {
        onInteractEvent.Invoke();
    }

    private void OnDisable()
    {
        customInput.Player.Movement.performed -= InputMovementPerformed;
        customInput.Player.Movement.canceled -= InputMovementCancelled;

        customInput.Player.Interact.performed -= InputInteractPerformed;

        customInput.Player.Hit.performed -= InputHitPerformedHandler;
    }

    private void InputHitPerformedHandler(InputAction.CallbackContext context)
    {
        onHitEvent.Invoke();
    }

    private void InputMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        onEnableMovementEvent.Invoke(moveInput);
    }

    private void InputMovementCancelled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        onEnableMovementEvent.Invoke(moveInput);
    }
}
