// 8/20/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform headHitPoint; // Điểm va chạm trên đầu
    public Transform leftHitPoint; // Điểm va chạm bên trái
    public Transform rightHitPoint; // Điểm va chạm bên phải
    public GameManager gameManager; // Tham chiếu đến GameManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Lấy vị trí va chạm
            Vector2 contactPoint = collision.bounds.center;
            Debug.Log("Contact Point: " + contactPoint);
            Debug.Log("Enemy Position: " + transform.position);

            // Kiểm tra nếu Player đứng trên đầu
            if (contactPoint.y > transform.position.y + 0.5f)
            {
                Debug.Log("Player hit the head!");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Player hit the side!");
                gameManager.GameOver();
            }
        }
    }
}
