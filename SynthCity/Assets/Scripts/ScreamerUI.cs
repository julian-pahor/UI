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
        //Sets all UI to the base starting values read from the backend
        pitchSlider.slider.value = screamer.pitch;
        volumeSlider.slider.value = screamer.volume;
        loopToggle.isOn = screamer.loop;
        pitchToggle.isOn = screamer.pitchSlide;
    }

    private void Update()
    {
        //Update here is used to update the frontend pitch position when pitch sliding is active
        pitchSlider.slider.value = screamer.pitch;
        //Updates a bool using an event trigger in the slider to detect whether the value is being changed or not
        screamer.pitchInteracting = pitchSlider.changing;
    }

    //All functions below are for the frontend -> backend communication of values
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
