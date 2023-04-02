using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    [SerializeField] private AudioManager manager;

    void Update()
    {
        manager.SaveSoundSettings();
    }
}
