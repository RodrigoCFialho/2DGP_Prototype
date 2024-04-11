using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private NoteController noteController = null;

    private BoxCollider2D boxCollider2D = null;

    [SerializeField]
    private float excellentHit = 0.10f;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        // Press W or ^ to hit the note
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (noteController == null)
        {
            return;
        }

        if (verticalInput > 0f && (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= ((boxCollider2D.size.x / 2) * excellentHit)))
        {
            noteController.iWasHit();
            noteController = null;
        }
        else if (verticalInput > 0f && (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= (boxCollider2D.size.x / 2)))
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
        }

        noteController = null;
    }

}
