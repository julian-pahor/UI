using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Settings settings;

    public FloatEditor musicVolume;
    public FloatEditor fxVolume;

    public Toggle stereo;

    private void Start()
    {
        musicVolume.slider.value = settings.musicVolume;
        fxVolume.slider.value = settings.soundFxVolume;

        stereo.isOn = settings.stereo;
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        stereo.isOn = settings.stereo;

        musicVolume.slider.value = settings.musicVolume;
        fxVolume.slider.value = settings.soundFxVolume;

        int musicV = (int)musicVolume.slider.value;
        musicVolume.input.text = musicV.ToString();

        int fxV = (int)fxVolume.slider.value;
        fxVolume.input.text = fxV.ToString();

    }

    public void OnMusicVolumeChanged(float volume)
    {
        settings.musicVolume = volume;

        int musicV = (int)musicVolume.slider.value;
        musicVolume.input.text = musicV.ToString();
    }

    public void OnFXVolumeChanged(float volume)
    {
        settings.soundFxVolume = volume;

        int fxV = (int)fxVolume.slider.value;
        fxVolume.input.text = fxV.ToString();
    }

    public void StereoToggle(bool toggle)
    {
        settings.stereo = toggle;
    }
}
