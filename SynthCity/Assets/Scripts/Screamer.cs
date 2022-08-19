using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : Module //Inherits from base class of Module
{
    public float volume;
    public float pitch;
    public bool loop = false;
    public bool pitchSlide = false;
    public bool pitchInteracting = false;

    public AudioClip[] screams;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        //Upon spawning this Module it sets itself a random audio clip from its array of audio clips
        source = GetComponent<AudioSource>();

        int rand = Random.Range(0, screams.Length);

        source.clip = screams[rand];
        source.volume = volume;

        if (UI.activeSelf)
        {
            this.UI.SetActive(false);
            this.uiOpen = false;
        }

    }

    private void Update()
    {
        //When loop it toggled on it detects when the audio clip starts and automatically starts it again
        if(loop && !source.isPlaying)
        {
            source.Play();
        }
        
        //Sets the audio source values based on the values within the script
        source.pitch = pitch;
        source.volume = volume;
        source.loop = loop;


        //Pitch Slide slides the pitch value back to 1 when it is true
        if(pitchSlide && !pitchInteracting)
        {
            if(source.pitch > 1.01)
            {
                pitch -= 0.005f;
            }
            else if (source.pitch < 0.99 )
            {
                pitch += 0.005f;
            }
            else
            {
                pitch = 1;
            }
        }
    }

    public override void InteractToggle()
    {
        //Required function declaration from the base class
        this.uiOpen = !this.uiOpen;
        this.UI.SetActive(!this.UI.activeSelf);
    }

    public void PlayOnce()
    {
        //Used by the UI button to play a clip once
        if (source != null)
        {
            source.PlayOneShot(source.clip);
        }
    }
}
