using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    NoteController NoteController = null;

    private void Update()
    {
        // Press W or ^ to hit the note
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (NoteController != null && NoteController.canHitNote && verticalInput > 0f)
        {
            NoteController.wasHit = true;
            NoteController.Dismiss();
            print("Hit");
        }
    }

    // Note enters the collider and can now be hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        NoteController = other.gameObject.GetComponent<NoteController>();

        if (NoteController != null)
        {
            NoteController.canHitNote = true;
            print("^");
        }
    }

    // Note exits the collider and is dismissed
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!NoteController.wasHit)
        {
            NoteController.canHitNote = false;
            NoteController.Dismiss();
            print("Miss");
        }
    }
}
