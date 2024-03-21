using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    private float speed = 2f;

    public bool canHitNote = false;

    public bool wasHit = false;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
