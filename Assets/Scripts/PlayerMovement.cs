using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 1f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    Animator animator;
    Vector2 moveInput;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    float startGravity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        startGravity = rb.gravityScale;
    }


    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove (InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if(!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
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

    void ClimbLadder()
    {
        bool playerHasVerticalMovement = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", playerHasVerticalMovement);

        if(capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            Vector2 climbVelocity = new Vector2 (rb.velocity.x, moveInput.y*climbSpeed);
            rb.velocity = climbVelocity;
            rb.gravityScale = 0f;
        } 
        else
        {
            rb.gravityScale = startGravity;
        }
    }

}
