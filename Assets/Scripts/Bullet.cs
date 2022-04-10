using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    PlayerMovement player;
    Rigidbody2D rb;
    float xSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }
    void Update()
    {
        rb.velocity = new Vector2 (xSpeed, 0f);
    }
}
