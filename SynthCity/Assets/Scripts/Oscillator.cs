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

    //public float[] frequencies;
    //public int thisFreq;

    public override void InteractToggle()
    {
        this.uiOpen = !this.uiOpen;
        this.UI.SetActive(!this.UI.activeSelf);
    }

    private void Start()
    {
        //frequencies = new float[8];
        //frequencies[0] = 440;
        //frequencies[1] = 494;
        //frequencies[2] = 554;
        //frequencies[3] = 587;
        //frequencies[4] = 659;
        //frequencies[5] = 740;
        //frequencies[6] = 831;
        //frequencies[7] = 880;
    }

    private void Update()
    {
        gain = volume;
        //freq = frequencies[thisFreq];
        //thisFreq++;

        //if (thisFreq >= frequencies.Length)
        //{
        //    thisFreq = 0;
        //}
    }
        
    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = freq * 2.0 * Mathf.PI / sampling_freq;

        for(int i = 0; i < data.Length; i += channels)
        {
            phase += increment;

            //Sin Wave
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            //Square Wave
            //if (gain * Mathf.Sin((float)phase) >= 0 * gain)
            //{
            //    data[i] = (float)gain * 0.6f;
            //}
            //else
            //{
            //    data[i] = (-(float)gain) * 0.6f;
            //}

            ////Triangle Wave
            //data[i] += (float) (gain * (double) Mathf.PingPong((float)phase, 1.0f));

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
