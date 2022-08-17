using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : Module
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
        if(loop && !source.isPlaying)
        {
            source.Play();
        }
        source.pitch = pitch;
        source.volume = volume;
        source.loop = loop;



        if(pitchSlide && !pitchInteracting)
        {
            if(source.pitch > 1.01)
            {
                pitch -= 0.0005f;
            }
            else if (source.pitch < 0.99 )
            {
                pitch += 0.0005f;
            }
            else
            {
                pitch = 1;
            }
        }
    }

    public override void InteractToggle()
    {
        this.uiOpen = !this.uiOpen;
        this.UI.SetActive(!this.UI.activeSelf);
    }

    public void PlayOnce()
    {
        if (source != null)
        {
            source.PlayOneShot(source.clip);
        }
    }
}
