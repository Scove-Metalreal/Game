using System;
using UnityEditor;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lấy Animator của Player
            Animator playerAnimator = collision.gameObject.GetComponent<Animator>();

            if (playerAnimator != null)
            {
                // Kích hoạt animation nhận sát thương
                playerAnimator.SetTrigger("isHit");
            }

            // Hủy Player sau khi animation hoàn thành
            Destroy(collision.gameObject, 0.5f); // Delay 0.5 giây để animation chạy xong
            gameManager.GameOver();
        }
    }
}
