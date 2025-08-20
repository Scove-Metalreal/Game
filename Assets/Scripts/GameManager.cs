// 8/20/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuScreen; // Màn hình Menu
    public GameObject gameOverScreen; // Màn hình Game Over
    public GameObject gameWinScreen;
    public Player player; // Tham chiếu đến Player

    private bool isGameActive = false;

    void Start()
    {
        // Hiển thị màn hình Menu khi bắt đầu game
        menuScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        gameWinScreen.SetActive(false);
        player.enabled = false; // Vô hiệu hóa Player khi ở màn hình Menu
    }

    public void StartGame()
    {
        // Bắt đầu game
        menuScreen.SetActive(false);
        isGameActive = true;
        player.enabled = true; // Kích hoạt Player
    }

    public void GameOver()
    {
        // Hiển thị màn hình Game Over
        gameOverScreen.SetActive(true);
        isGameActive = false;
        player.enabled = false; // Vô hiệu hóa Player
    }

    public void WinGame()
    {
        gameWinScreen.SetActive(true);
        isGameActive = false;
        player.enabled = false;
    }

    public void RestartGame()
    {
        // Reset lại màn chơi
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
