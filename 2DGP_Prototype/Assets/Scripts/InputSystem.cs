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
    private UnityEvent onUpHitEvent;

    [SerializeField]
    private UnityEvent onDownHitEvent;

    [SerializeField]
    private UnityEvent onPauseEvent;

    private void Start()
    {
        customInput = CustomInputManager.Instance.customInputsBindings;

        customInput.Player.Movement.performed += InputMovementPerformed;
        customInput.Player.Movement.canceled += InputMovementCancelled;

        customInput.Player.Interact.performed += InputInteractPerformed;

        customInput.Player.UpHit.performed += InputUpHitPerformedHandler;

        customInput.Player.DownHit.performed += InputDownHitPerformedHandler;

        customInput.Player.Pause.performed += InputPausePerformedHandler;
    }

    private void OnDisable()
    {
        customInput.Player.Movement.performed -= InputMovementPerformed;
        customInput.Player.Movement.canceled -= InputMovementCancelled;

        customInput.Player.Interact.performed -= InputInteractPerformed;

        customInput.Player.UpHit.performed -= InputUpHitPerformedHandler;

        customInput.Player.DownHit.performed -= InputDownHitPerformedHandler;

        customInput.Player.Pause.performed -= InputPausePerformedHandler;
    }

    private void InputMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        onEnableMovementEvent.Invoke(moveInput);
    }

    private void InputInteractPerformed(InputAction.CallbackContext context)
    {
        onInteractEvent.Invoke();
    }

    private void InputUpHitPerformedHandler(InputAction.CallbackContext context)
    {
        onUpHitEvent.Invoke();
    }

    private void InputDownHitPerformedHandler(InputAction.CallbackContext context)
    {
        onDownHitEvent.Invoke();
    }

    private void InputPausePerformedHandler(InputAction.CallbackContext context)
    {
        onPauseEvent.Invoke();
    }

    private void InputMovementCancelled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
        onEnableMovementEvent.Invoke(moveInput);
    }
}
