using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Settings settings;

    public SliderEditor masterSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        masterSlider.slider.value = settings.masterVolume;

    }

    
    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        masterSlider.slider.value = settings.masterVolume;

        int master = (int) masterSlider.slider.value;
        masterSlider.input.text = master.ToString();
    }

    public void OnMasterVolumeChanged(float value)
    {
        settings.masterVolume = value;

        int master = (int)masterSlider.slider.value;
        masterSlider.input.text = master.ToString();
    }
}
