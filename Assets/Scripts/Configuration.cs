using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Configuration : MonoBehaviour
{
    public delegate void SliderValue(float value);
    public static event SliderValue OnTextPrintSpeedChanged;
    public static event SliderValue OnTextBoxOpacityChanged;
    public static event SliderValue OnMusicVolumeChanged;
    public static event SliderValue OnSfxVolumeChanged;
    public static event SliderValue OnVoiceVolumeChanged;
    
    [SerializeField] private Slider textPrintSpeedSlider;
    [SerializeField] private Slider textBoxOpacitySlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider voiceVolumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    
    private void Start()
    {
        textPrintSpeedSlider.onValueChanged.AddListener(UpdateTextPrintSpeed);
        textBoxOpacitySlider.onValueChanged.AddListener(UpdateTextBoxOpacity);
        musicVolumeSlider.onValueChanged.AddListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(UpdateSfxVolume);
        voiceVolumeSlider.onValueChanged.AddListener(UpdateVoiceVolume);
    }

    private void OnDestroy()
    {
        textPrintSpeedSlider.onValueChanged.RemoveListener(UpdateTextPrintSpeed);
        textBoxOpacitySlider.onValueChanged.RemoveListener(UpdateTextBoxOpacity);
        musicVolumeSlider.onValueChanged.RemoveListener(UpdateMusicVolume);
        sfxVolumeSlider.onValueChanged.RemoveListener(UpdateSfxVolume);
        voiceVolumeSlider.onValueChanged.RemoveListener(UpdateVoiceVolume);
    }

    private void UpdateTextPrintSpeed(float sliderValue) => OnTextPrintSpeedChanged?.Invoke(sliderValue);
    private void UpdateTextBoxOpacity(float sliderValue) => OnTextBoxOpacityChanged?.Invoke(sliderValue);
    private void UpdateMusicVolume(float sliderValue) => UpdateVolume("Music", sliderValue, OnMusicVolumeChanged);
    private void UpdateSfxVolume(float sliderValue) => UpdateVolume("SFX", sliderValue, OnSfxVolumeChanged);
    private void UpdateVoiceVolume(float sliderValue) => UpdateVolume("Voice", sliderValue, OnVoiceVolumeChanged);
    
    private void UpdateVolume(string mixerGroup, float sliderValue, SliderValue sliderEvent)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        audioMixer.SetFloat(mixerGroup, volume);
        sliderEvent?.Invoke(sliderValue);
    }
}
