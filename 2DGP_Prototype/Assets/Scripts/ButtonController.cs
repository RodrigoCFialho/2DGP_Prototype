using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private NoteController noteController = null;

    private void Update()
    {
        // Press W or ^ to hit the note
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0f && noteController != null)
        {
            noteController.iWasHit();
            noteController = null;
        }
    }

    // Note enters the collider and can now be hit
    private void OnTriggerEnter2D(Collider2D other)
    {
        noteController = other.gameObject.GetComponent<NoteController>();

        if (noteController != null)
        {
            print("^");
        }
    }

    // Note exits the collider and is dismissed
    private void OnTriggerExit2D(Collider2D other)
    {

        if (!noteController.wasHit)
        {
            noteController.iWasNotHit();
            noteController = null;
        }
    }
}
