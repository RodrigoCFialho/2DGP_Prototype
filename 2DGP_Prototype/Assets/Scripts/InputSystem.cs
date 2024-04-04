using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<float> OnEnableHorizontalInput;
    [SerializeField]
    private UnityEvent<float> OnEnableVerticalInput;
    [SerializeField]
    private UnityEvent OnEnableLevel;
    [SerializeField]
    private UnityEvent OnDisableLevel;

    private void Update()
    {
        
    }
}
