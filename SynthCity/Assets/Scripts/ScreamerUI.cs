using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ScreamerUI : MonoBehaviour
{

    public Screamer screamer;

    public SliderEditor pitchSlider;
    public SliderEditor volumeSlider;

    public Toggle loopToggle;
    public Toggle pitchToggle;


    // Start is called before the first frame update
    void Start()
    {
        pitchSlider.slider.value = screamer.pitch;
        volumeSlider.slider.value = screamer.volume;
        loopToggle.isOn = screamer.loop;
        pitchToggle.isOn = screamer.pitchSlide;
    }

    private void Update()
    {
        pitchSlider.slider.value = screamer.pitch;
        screamer.pitchInteracting = pitchSlider.changing;
    }
    public void OnPitchChange(float value)
    {
        screamer.pitch = value;
        pitchSlider.input.text = value.ToString();
    }

    public void OnVolumeChange(float value)
    {
        screamer.volume = value;
        volumeSlider.input.text = value.ToString();
    }

    public void ScreamButton()
    {
        screamer.PlayOnce();
    }

    public void OnLoopToggleChange(bool value)
    {
        screamer.loop = value;
    }

    public void OnSlideToggleChange(bool value)
    {
        screamer.pitchSlide = value;
    }

    
}
