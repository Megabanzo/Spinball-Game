using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider Mslider;
    public Slider SEslider;

    void Start()
    {
        Mslider.value = PlayerPrefs.GetFloat("MusicVolume");
        SEslider.value = PlayerPrefs.GetFloat("SoundEffectVolume");
        if (GameMaster.firstoption == true)
        {
            GameMaster.firstoption = false;
            Mslider.value = 0.5f;
            SEslider.value = 0.5f;
        }
        mixer.SetFloat("Music_Volume", Mathf.Log10(Mslider.value) * 20);
        mixer.SetFloat("SoundEffect_Volume", Mathf.Log10(SEslider.value) * 20);
    }

    public void SetLevelMusic()
    {
        mixer.SetFloat("Music_Volume", Mathf.Log10(Mslider.value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", Mslider.value);
        // Debug.Log(sliderValue);
    }

    public void SetLevelSoundEffect()
    {
        mixer.SetFloat("SoundEffect_Volume", Mathf.Log10(SEslider.value) * 20);
        PlayerPrefs.SetFloat("SoundEffectVolume", SEslider.value);
        // Debug.Log(sliderValue);
    }
}