using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D myRigidbody2D = null;
    
    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
