using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    public float noteValue = 5f;

    [SerializeField]
    private float noteValuePerfect = 10f;

    [SerializeField]
    private float speed = 2f;

    public bool canHitNote = false;

    public bool wasHit = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();;
    }

    private void Start()
    {
        // Make notes move to the left
        myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
    }

    public void iWasHit()
    {
        wasHit = true;
        GameManager.Instance.AddScore(noteValue);
        UiManager.Instance.EnableGoodText();
        Dismiss();

    }

    public void iWasNotHit()
    {
        GameManager.Instance.AddScore(-noteValue);
        UiManager.Instance.EnableMissText();
        Dismiss();
    }

    public void iWasHitPerfect()
    {
        wasHit = true;
        GameManager.Instance.AddScore(noteValuePerfect);
        UiManager.Instance.EnablePerfectText();
        Dismiss();
    }

    // Destroy the Note
    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
