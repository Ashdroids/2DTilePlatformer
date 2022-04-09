using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 1f;
    Vector2 moveInput;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Run();
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
    }
}
