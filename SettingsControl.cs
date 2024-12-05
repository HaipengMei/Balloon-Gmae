using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject sliderPanel;
    void Start()
    {
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Update is called once per frame
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void OpenSettings(){
        sliderPanel.SetActive(true);//Make slider become visible
    }
    public void BackToMenu(){
        sliderPanel.SetActive(false);//make slider become invisible which mean back to main menu
    }
}
