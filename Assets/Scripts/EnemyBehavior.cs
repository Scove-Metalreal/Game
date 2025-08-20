using System;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform headHitPoint; // Điểm va chạm trên đầu
    public Transform leftHitPoint; // Điểm va chạm bên trái
    public Transform rightHitPoint; // Điểm va chạm bên phải
    public EnemyShooting enemyShooting;

    private Animator _animator; // Tham chiếu tới Animator
    private static readonly int IsHitTrigger = Animator.StringToHash("isHit");
    public GameManager gameManager;

    void Start()
    {
        // Lấy Animator từ Enemy
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm với Player
        if (collision.CompareTag("Player"))
        {
            // Lấy vị trí va chạm
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);

            // Kiểm tra va chạm với Head Hit Point
            if (IsPointNear(collisionPoint, headHitPoint.position))
            {
                // Enemy nhận sát thương
                TakeDamage();
            }
            // Kiểm tra va chạm với Left hoặc Right Hit Point
            else if (IsPointNear(collisionPoint, leftHitPoint.position) || IsPointNear(collisionPoint, rightHitPoint.position))
            {
                // Player nhận sát thương
                PlayerTakeDamage(collision.gameObject);
            }
        }

        // Kiểm tra nếu va chạm với đạn của Player
        if (collision.CompareTag("Bullet"))
        {
            // Enemy nhận sát thương
            TakeDamage();

            // Hủy đạn sau khi va chạm
            Destroy(collision.gameObject);
        }
    }

    private bool IsPointNear(Vector2 point, Vector2 target, float threshold = 0.5f)
    {
        // Kiểm tra khoảng cách giữa điểm va chạm và điểm mục tiêu
        return Vector2.Distance(point, target) <= threshold;
    }

    private void TakeDamage()
    {
        // Kích hoạt animation nhận sát thương
        _animator.SetTrigger(IsHitTrigger);

        // Hủy Enemy sau khi animation hoàn thành
        Destroy(gameObject, 0.5f); // Delay 0.5 giây để animation chạy xong
    }

    private void PlayerTakeDamage(GameObject player)
    {
        // Lấy Animator của Player
        Animator playerAnimator = player.GetComponent<Animator>();
        if (playerAnimator != null)
        {
            // Kích hoạt animation nhận sát thương của Player
            playerAnimator.SetTrigger(IsHitTrigger);
        }

        // Hủy Player sau khi animation hoàn thành
        Destroy(player, 0.5f); // Delay 0.5 giây để animation chạy xong
        gameManager.GameOver();
    }
    
    void ToggleShooting(bool enable)
    {
        if (enemyShooting != null)
        {
            enemyShooting.canShoot = enable;
        }
    }
}
