using System;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int JumpTrigger = Animator.StringToHash("isJumping");
    private static readonly int AttackTrigger = Animator.StringToHash("isAttacking");
    private static readonly int HitTrigger = Animator.StringToHash("isHit");
    private static readonly int SmallHitTrigger = Animator.StringToHash("isSmallHit");

    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D _rb;

    private bool _isGrounded = false;
    public Transform groundCheck;   // Empty GameObject to check ground position
    public float groundCheckRadius = 0.2f; // Radius for ground check
    public LayerMask groundMask;    // layer for ground objects

    private Vector3 _originalScale;

    private Animator _animator; // Reference to Animator
    
    public GameManager gameManager; // Tham chiếu đến GameManager
    
    public AudioClip jumpSound;
    private AudioSource _audioSource;

    void Start()
    {
        // get the RigidBody 2d
        _rb = GetComponent<Rigidbody2D>();
        
        // store the original scale of the player
        _originalScale = transform.localScale;

        // get the Animator component
        _animator = GetComponent<Animator>();
        
        _audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        // handle horizontal movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, _rb.linearVelocity.y);

        // flip based on movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(_originalScale.x, _originalScale.y, _originalScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-_originalScale.x, _originalScale.y, _originalScale.z);
        }

        // Update isRunning parameter
        _animator.SetBool(IsRunning, horizontalInput != 0);

        // Check if grounded
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        // handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            _animator.SetTrigger(JumpTrigger); // Use Trigger for jumping

            if (jumpSound != null)
            {
                _audioSource.PlayOneShot(jumpSound);
            }
            else
            {
                Debug.Log("Jump sound not played");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            gameManager.GameOver();
        }
    }

    public void TakeSmallHit()
    {
        // Example: Trigger small hit animation
        _animator.SetTrigger(SmallHitTrigger); // Use Trigger for small hit
    }
    
}
