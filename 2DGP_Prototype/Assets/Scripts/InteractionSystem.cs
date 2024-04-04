using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    private IInteractible interactible = null;
    private bool canInteract = true;

    private CustomInput customInput;

    private void Start()
    {
        customInput = CustomInputManager.Instance.GetCustomInput();
        customInput.Player.Interact.Enable();

        customInput.Player.Interact.performed += InputInteractPerformedHandler;
    }

    private void OnDestroy()
    {
        customInput.Player.Interact.performed -= InputInteractPerformedHandler;
    }

    private void InputInteractPerformedHandler(InputAction.CallbackContext context)
    {
        Interact();
    }

    private void Interact()
    {
        if (canInteract && interactible != null)
        {
            interactible.Interact();
        }
    }

    public void EnableInteraction()
    {
        canInteract = true;
    }

    public void DisableInteraction()
    {
        canInteract = false;
    }

    public void SetInteractible(IInteractible interactibleObject)
    {
        interactible = interactibleObject;
    }
}
