// 8/19/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerCoinManager : MonoBehaviour
{
    public static PlayerCoinManager Instance; // Singleton Instance
    public int totalCoins = 0; // Tổng số coin của người chơi
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        // Đảm bảo chỉ có một Instance của PlayerCoinManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại khi chuyển Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount; // Tăng số lượng coin
        Debug.Log("Coins Collected: " + totalCoins); // Hiển thị số coin (tùy chọn)
        coinsText.text = totalCoins.ToString();
    }

    public int GetTotalCoins()
    {
        return totalCoins; // Trả về tổng số coin
    }
}
