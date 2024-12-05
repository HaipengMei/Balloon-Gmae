using UnityEngine;
using UnityEngine.UI;


public class MusicTrigger : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Toggle musicToggle; 
    void Start()
    {
        if (backgroundMusic != null && musicToggle != null)
        {
            musicToggle.isOn = backgroundMusic.isPlaying;
            musicToggle.onValueChanged.AddListener(HandleToggleMusic);
        }
    }



    public void HandleToggleMusic(bool isOn)
    {
        if (backgroundMusic != null)
        {
            if (isOn)
            {
                backgroundMusic.Play();
                Debug.Log("Music started playing.");
            }
            else
            {
                backgroundMusic.Pause();
                Debug.Log("Music paused.");
            }
        }
    }
}
