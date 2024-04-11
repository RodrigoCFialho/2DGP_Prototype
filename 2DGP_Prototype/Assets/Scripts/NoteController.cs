using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    private UiManager uiManager = null;

    [SerializeField]
    private float noteValue = 5f;

    private float noteValueExcellent = 10f;

    [SerializeField]
    private float speed = 2f;

    public bool canHitNote = false;

    public bool wasHit = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<UiManager>();
    }

    private void Start()
    {
        // Make notes move to the left
        myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Dismiss();
        }
    }

    public void iWasHit()
    {
        wasHit = true;
        Dismiss();
        uiManager.AddScore(noteValue);
        uiManager.EnableGoodText();
        print("Good");
    }

    public void iWasNotHit()
    {
        Dismiss();
        uiManager.AddScore(-noteValue);
        print("Miss");
    }

    public void iWasHitExcellent()
    {
        wasHit = true;
        Dismiss();
        uiManager.AddScore(noteValueExcellent);
        uiManager.EnableExcellentText();
        print("Excellent");

    }

    // Destroy the Note
    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
