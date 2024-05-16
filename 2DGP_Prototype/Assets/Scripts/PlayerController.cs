using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    private Animator myAnimator = null;

    [SerializeField]
    private float speed = 3f;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    public void EnableMovementEvent(Vector2 moveInput)
    {
        // movement
        myRigidbody2D.velocity = moveInput * speed;

        // animations
        myAnimator.SetFloat("VerticalSpeed", myRigidbody2D.velocity.y);
        myAnimator.SetFloat("HorizontalSpeed", myRigidbody2D.velocity.x);
    }
}
