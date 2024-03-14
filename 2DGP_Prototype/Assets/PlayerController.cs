using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    [SerializeField]
    private float speed = 3f;


    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float verticalinput = Input.GetAxisRaw("Vertical");
        float horizontalinput = Input.GetAxisRaw("Horizontal");

        myRigidbody2D.velocity = new Vector2(horizontalinput * speed, verticalinput * speed);
    }
}
