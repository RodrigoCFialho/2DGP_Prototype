using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{
    private NoteController noteController = null;

    private BoxCollider2D boxCollider2D = null;

    [SerializeField]
    private float perfectHit = 0.10f;

    private Vector2 upInput;

    private CustomInput customInput;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        customInput = CustomInputManager.Instance.GetCustomInput();
        customInput.Player.UP.Enable();

        customInput.Player.UP.performed += InputUpPerformedHandler;
        customInput.Player.UP.canceled += InputUpCancelledHandler;
    }

    private void OnDestroy()
    {
        customInput.Player.UP.performed -= InputUpPerformedHandler;
        customInput.Player.UP.canceled -= InputUpCancelledHandler;
    }

    private void InputUpCancelledHandler(InputAction.CallbackContext context)
    {
        upInput = Vector2.zero;
    }

    private void InputUpPerformedHandler(InputAction.CallbackContext context)
    {
        upInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Press W or ^ to hit the note
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (noteController == null)
        {
            return;
        }

        if (verticalInput > 0f && (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= (boxCollider2D.size.x * perfectHit)))
        {
            noteController.iWasHitPerfect();
            noteController = null;
        }
        else if (verticalInput > 0f && (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= boxCollider2D.size.x))
        {
            noteController.iWasHit();
            noteController = null;
        }
    }

    // Note enters the collider and can now be hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        noteController = other.gameObject.GetComponent<NoteController>();
    }

    // Note exits the collider and is dismissed
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!noteController.wasHit)
        {
            noteController.iWasNotHit();
        }

        noteController = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, (boxCollider2D.size) * perfectHit);
    }

}
