// 8/20/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // Giá trị của coin
    public AudioClip coinSound; // Âm thanh khi nhặt coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Phát âm thanh khi nhặt coin
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, transform.position);
            }

            if (PlayerCoinManager.Instance != null)
            {
                PlayerCoinManager.Instance.AddCoins(coinValue);
            }
            else
            {
                Debug.Log("Player coin not found");
            }

            // Thêm logic tăng điểm hoặc xử lý khác ở đây
            Debug.Log("Coin collected!");

            // Hủy đối tượng coin
            Destroy(gameObject);
        }
    }
}
