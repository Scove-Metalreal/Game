using System;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to spawn
    public Transform bulletSpawner; // The position from where the bullet will be spawned
    public float bulletSpeed = 10f; // Speed of the bullet

    private bool _isFacingRight = true; // Track the player's facing direction

    void Update()
    {
        // Check for shooting input
        if (Input.GetButtonDown("Fire1")) // Default "Fire1" is left mouse button
        {
            Shoot();
        }

        // Update facing direction (optional, if you flip the player elsewhere)
        if (transform.localScale.x > 0)
        {
            _isFacingRight = true;
        }
        else
        {
            _isFacingRight = false;
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawner's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

        // Add velocity to the bullet's Rigidbody2D to make it move
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            // Determine the direction of the bullet based on the player's facing direction
            Vector2 bulletDirection = _isFacingRight ? Vector2.right : Vector2.left;

            // Apply velocity to the bullet
            bulletRb.linearVelocity = bulletDirection * bulletSpeed;
        }
    }
}
