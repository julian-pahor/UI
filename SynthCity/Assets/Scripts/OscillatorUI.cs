using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OscillatorUI : MonoBehaviour
{
    public Oscillator osc;

    public SliderEditor freqSlider;
    public SliderEditor fineSlider;
    public SliderEditor volumeSlider;

    void Start()
    {
        //Intialise all front end UI values from the backend
        freqSlider.slider.value = (float) osc.freq;
        volumeSlider.slider.value = (float) osc.volume;
        fineSlider.slider.value = 0;
    }

    //All functions below are to update the backend values from frontend UI interaction

    public void OnFreqChange(float value)
    {
        osc.freq = value;
        float freqV = freqSlider.slider.value;
        freqSlider.input.text = freqV.ToString();
        
    }

    public void OnFineChange(float value)
    {
        osc.freq = freqSlider.slider.value + value;
        float fineV = fineSlider.slider.value;
        fineSlider.input.text = fineV.ToString();
    }

    public void OnVolumeChange(float value)
    {
        osc.volume = value;
        float volumeV = volumeSlider.slider.value;
        volumeSlider.input.text = volumeV.ToString();
    }
}
