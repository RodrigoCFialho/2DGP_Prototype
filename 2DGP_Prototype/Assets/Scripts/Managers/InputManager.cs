using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Vector2 NavigationInput {  get; set; }

    private InputAction navigationAction;

    public static PlayerInput PlayerInput { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        PlayerInput = GetComponent<PlayerInput>();
        navigationAction = PlayerInput.actions["Navigate"];
    }

    private void Update()
    {
        NavigationInput = navigationAction.ReadValue<Vector2>();
    }
}
