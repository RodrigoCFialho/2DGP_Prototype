using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    public float noteValue = 5f;

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
        UiManager.Instance.AddScore(noteValue);
        UiManager.Instance.EnableGoodText();
        print("Good");
        Dismiss();

    }

    public void iWasNotHit()
    {
        UiManager.Instance.AddScore(-noteValue);
        UiManager.Instance.EnableMissText();
        print("Miss");
        Dismiss();
    }

    public void iWasHitPerfect()
    {
        wasHit = true;
        UiManager.Instance.AddScore(noteValuePerfect);
        UiManager.Instance.EnablePerfectText();
        print("Perfect");
        Dismiss();
    }

    // Destroy the Note
    private void Dismiss()
    {
        Destroy(gameObject);
    }
}
