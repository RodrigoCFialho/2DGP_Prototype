using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    private IInteractible interactable = null;

    public void InteractEvent()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    public void SetInteractible(IInteractible interactableObject)
    {
        interactable = interactableObject;
    }
}
