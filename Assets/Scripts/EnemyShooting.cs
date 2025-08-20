// 8/20/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab; // Prefab của đạn
    public Transform firePoint; // Vị trí bắn đạn
    public float fireRate = 1f; // Tốc độ bắn (số giây giữa mỗi lần bắn)
    public float bulletSpeed = 10f; // Tốc độ bay của đạn

    [Header("Shooting Toggle")]
    public bool canShoot = false; // Công tắc bật/tắt bắn

    private float fireCooldown = 0f;

    void Update()
    {
        // Nếu công tắc bật và cooldown đã hết, bắn đạn
        if (canShoot && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate; // Reset cooldown
        }

        // Giảm cooldown theo thời gian
        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            // Tạo đạn tại vị trí firePoint
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Kiểm tra xem đạn có Rigidbody2D không
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Thêm lực để đạn bay về phía trước
                rb.linearVelocity = firePoint.right * bulletSpeed;
            }
            else
            {
                Debug.LogWarning("Bullet prefab không có Rigidbody2D!");
            }
        }
        else
        {
            Debug.LogWarning("BulletPrefab hoặc FirePoint chưa được gán!");
        }
    }
}
