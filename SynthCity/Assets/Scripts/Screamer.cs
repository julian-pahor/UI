using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screamer : Module
{
    public float volume;
    public float pitch;
    public bool loop = false;
    public bool pitchSlide = false;

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

        if(pitchSlide)
        {
            if(source.pitch > 1)
            {
                source.pitch -= 0.001f;
            }
            else if (source.pitch < 1 )
            {
                source.pitch += 0.001f;
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
