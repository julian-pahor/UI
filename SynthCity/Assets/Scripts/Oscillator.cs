using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : Module
{
    public double freq;

    private double increment;
    private double phase;
    private double sampling_freq = 48000.0;

    public float gain;
    public float volume = 0.3f;
    
    

    public override void InteractToggle()
    {
        this.uiOpen = !this.uiOpen;
        this.UI.SetActive(!this.UI.activeSelf);
    }

    private void Start()
    {
        if(UI.activeSelf)
        {
            this.UI.SetActive(false);
            this.uiOpen = false;
        }
        
    }

    private void Update()
    {
        gain = volume;
    }
        
    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = freq * 2.0 * Mathf.PI / sampling_freq;

        for(int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

            ////Sin Wave
            //data[i] = (float)(gain * Mathf.Sin((float)phase));

            //Square Wave
            //if (gain * Mathf.Sin((float)phase) >= 0 * gain)
            //{
            //    data[i] = (float)gain * 0.6f;
            //}
            //else
            //{
            //    data[i] = (-(float)gain) * 0.6f;
            //}

            //Triangle Wave
            data[i] += (float)(gain * (double)Mathf.PingPong((float)phase, 1.0f));

            //make it stereo 
            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0;
            }
        }
    }
}
