using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeText;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volumeSlider.value.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volume = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volume);
        LoadValues();

    }

    private void LoadValues()
    {
        float volumevalue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumevalue;
        AudioListener.volume = volumevalue;
    }
}
