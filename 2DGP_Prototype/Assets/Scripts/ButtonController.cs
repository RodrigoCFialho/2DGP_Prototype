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

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void HitEvent()
    {
        if (noteController == null)
        {
            UiManager.Instance.AddScore(-10f);
            UiManager.Instance.EnableMissText();
            print("Miss");
        }
        else if (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= (boxCollider2D.size.x * perfectHit))
        {
            noteController.iWasHitPerfect();
            noteController = null;
        }
        else if (Mathf.Abs(noteController.transform.position.x - this.transform.position.x) <= boxCollider2D.size.x)
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
