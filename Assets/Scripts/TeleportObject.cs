// 8/19/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Transform teleportDestination; // Vị trí mà Player sẽ được teleport đến

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.CompareTag("Player"))
        {
            // Di chuyển Player đến vị trí teleportDestination
            collision.transform.position = teleportDestination.position;

            // Debugging log (tùy chọn)
            Debug.Log("Player has been teleported!");
        }
    }
}
