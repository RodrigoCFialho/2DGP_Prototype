using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{
    private NoteController noteController = null;

    private BoxCollider2D myBoxCollider2D = null;

    [SerializeField]
    private float perfectHit = 0.10f;

    private void Awake()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void HitEvent()
    {
        if (noteController == null)
        {
            GameManager.Instance.AddScore(-10f);
            UiManager.Instance.EnableMissText();
        }
        else if (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= (myBoxCollider2D.size.x * perfectHit))
        {
            noteController.iWasHitPerfect();
            noteController = null;
        }
        else if (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= myBoxCollider2D.size.x)
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
}
