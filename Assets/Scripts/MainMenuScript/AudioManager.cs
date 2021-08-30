using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider musicSlider;
    public Slider guiSlider;
    public Slider fxSlider;
    GameObject gameManager;
    
    //public AudioSource buttonSelect;
    //public AudioSource buttonHover;

    void Start()
    {
        mainMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("musicVolume"));
        mainMixer.SetFloat("GuiVolume", PlayerPrefs.GetFloat("guiVolume"));
        mainMixer.SetFloat("FxVolume", PlayerPrefs.GetFloat("fxVolume"));
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1f);
        guiSlider.value = PlayerPrefs.GetFloat("guiVolume", 1f);
        fxSlider.value = PlayerPrefs.GetFloat("fxVolume", 1f);
        //buttonSelect.playOnAwake = false;
        //buttonHover.playOnAwake = false;
        gameManager = GameObject.Find("GameManager");
    }

    public void SetMusicVol(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 40);
        PlayerPrefs.SetFloat("musicVolume", sliderValue);
    }

    public void SetFxVolume(float sliderValue)
    {
        mainMixer.SetFloat("FxVolume", Mathf.Log10(sliderValue) * 40);
        PlayerPrefs.SetFloat("fxVolume", sliderValue);
    }

    public void SetGuiVolume(float sliderValue)
    {
        mainMixer.SetFloat("GuiVolume", Mathf.Log10(sliderValue) * 40);
        PlayerPrefs.SetFloat("guiVolume", sliderValue);
    }

    
   

  
}
