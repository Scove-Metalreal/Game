using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false; // Trạng thái mute
    public Slider volumeSlider;

    public void ToggleMute()
    {
        isMuted = !isMuted; // Đảo trạng thái mute
        AudioListener.volume = isMuted ? 0 : 1; // Nếu mute thì âm lượng = 0, ngược lại = 1
        Debug.Log("Game is " + (isMuted ? "Muted" : "Unmuted"));
    }
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
        Debug.Log("Volume set to: " + volume);
        Save();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
