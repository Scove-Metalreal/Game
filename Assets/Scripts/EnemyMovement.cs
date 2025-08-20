// 8/19/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.0f; // Tốc độ di chuyển của Enemy
    public Transform pointA;  // Điểm A
    public Transform pointB;  // Điểm B

    private bool _movingToPointA = true; // Biến kiểm tra hướng di chuyển
    private Vector3 _originalScale;     // Lưu lại scale ban đầu của Enemy

    private static readonly int IsHitTrigger = Animator.StringToHash("isHit");

    void Start()
    {
        // Lưu lại scale ban đầu
        _originalScale = transform.localScale;
    }

    void Update()
    {
        // Di chuyển Enemy giữa Point A và Point B
        if (_movingToPointA)
        {
            MoveTowardsTarget(pointA.position);
        }
        else
        {
            MoveTowardsTarget(pointB.position);
        }
    }

    private void MoveTowardsTarget(Vector3 target)
    {
        // Di chuyển Enemy về phía target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Tính khoảng cách tới target
        float distance = Vector3.Distance(transform.position, target);

        // Nếu Enemy gần target, đổi hướng di chuyển
        if (distance <= 0.2f) // Ngưỡng khoảng cách để đổi hướng
        {
            _movingToPointA = !_movingToPointA;

            // Đổi hướng bằng cách lật scale X
            Vector3 newScale = _originalScale;
            newScale.x = _movingToPointA ? Mathf.Abs(_originalScale.x) : -Mathf.Abs(_originalScale.x);
            transform.localScale = newScale;
        }
    }
}
