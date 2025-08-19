using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D _rb;

    private bool _isGrounded = false;
    public Transform groundCheck;   // Empty GameObject to check ground position
    public float groundCheckRadius = 0.2f; // Radius for ground check
    public LayerMask groundMask;    // layer for ground objects

    private Vector3 _originalScale;

    void Start()
    {
        // get the RigidBody 2d
        _rb = GetComponent<Rigidbody2D>();
        
        // store the original scale of the player
        _originalScale = transform.localScale;
    }

    [Obsolete("Obsolete")]
    void Update()
    {
        // handle horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * moveSpeed, _rb.velocity.y);
        
        // flip based on movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(_originalScale.x, _originalScale.y, _originalScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-_originalScale.x, _originalScale.y, _originalScale.z);
        }
        
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        
        // handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
