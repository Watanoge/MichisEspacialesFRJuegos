using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void SetMusicLevelVolume(float sliderValue)
    {
        masterMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Music Volume", sliderValue);
    }
    public void SetSFXLevelVolume(float sliderValue)
    {
        masterMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX Volume", sliderValue);
    }
}
