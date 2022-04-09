using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 1f;
    Animator animator;
    Vector2 moveInput;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x*runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalMovement = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        animator.SetBool("isRunning", playerHasHorizontalMovement);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalMovement = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalMovement)
        {
            transform.localScale = new Vector2 (Mathf.Sign(rb.velocity.x) , 1f);
        }
    }
}
