using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D myRigidbody2D = null;

    private bool startGame = false;
    
    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!startGame && Input.GetKeyDown(KeyCode.E))
        {
            startGame = true;
        }
    }

    private void FixedUpdate()
    {
        if (startGame)
        {
            myRigidbody2D.velocity = new Vector2(-speed, myRigidbody2D.velocity.y);
        }
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}
