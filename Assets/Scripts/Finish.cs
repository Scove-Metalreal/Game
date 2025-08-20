using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI finishScoreText;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.gameObject.CompareTag("Player"))
        {
            Score();
            gameManager.WinGame();
        }
    }

    private void Score()
    {
        finishScoreText.text = PlayerCoinManager.Instance.totalCoins.ToString();
    }
}