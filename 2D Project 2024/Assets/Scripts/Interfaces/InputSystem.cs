using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> OnEnableVerticalInput;

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        OnEnableVerticalInput.Invoke(verticalInput);
    }
}
