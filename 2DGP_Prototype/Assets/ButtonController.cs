using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    NoteController NoteController = null;


    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0f && NoteController.canHitNote && NoteController != null)
        {
            NoteController.wasHit = true;
            NoteController.Dismiss();
            print("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NoteController = other.gameObject.GetComponent<NoteController>();

        if (NoteController != null)
        {
            NoteController.canHitNote = true;
            print("^");
        }
    }

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
