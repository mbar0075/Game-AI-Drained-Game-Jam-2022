using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private static string BackgroundPref = ("BackgroundPref");
    private static string SoundEffectsPref = ("SoundEffectsPref");
    public AudioSource backgroundAudio;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;

    void Awake()
    {
        ContinueSettings();      
    }

    private void ContinueSettings()
    {
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);

        backgroundAudio.volume = backgroundFloat;
        
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
