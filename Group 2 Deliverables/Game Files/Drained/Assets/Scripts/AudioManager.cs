using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static string FirstPlay = "FirstPlay";
    private static string BackgroundPref = "BackgroundPref";
    private static string SoundEffectsPref = ("SoundEffectsPref");
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        backgroundAudio.Play(); 
        UpdateSound();

        if(firstPlayInt == 0)
        {   
            backgroundFloat = 1f;
            soundEffectsFloat = 1f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
        PlayerPrefs.Save();
    }

    void OnApplicationFocus()
    {
        if(!Application.isFocused)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;
        
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
        
    }
}
