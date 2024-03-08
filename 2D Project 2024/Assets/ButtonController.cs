using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    private bool canHitNote = false;

    NoteController NoteController = null;


    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput > 0f && canHitNote)
        {
            NoteController.Dismiss();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoteController = collision.gameObject.GetComponent<NoteController>();

        if (NoteController != null)
        {
            canHitNote = true;
        }
    }
}
