using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    private bool canHitNote = false;

    private bool wasHit = false;

    NoteController NoteController = null;


    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0f && canHitNote && NoteController != null)
        {
            wasHit = true;
            NoteController.Dismiss();
            print("Hit");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        NoteController = other.gameObject.GetComponent<NoteController>();

        if (NoteController != null)
        {
            canHitNote = true;
            print("^");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!wasHit)
        {
            canHitNote = false;
            NoteController.Dismiss();
            print("Miss");
        }
    }
}
