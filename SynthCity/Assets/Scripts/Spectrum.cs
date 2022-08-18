using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : Module
{
    
    public SpectrumAnalyser analyser;
    float[] spectrum = new float[256];

    private void Start()
    {
        uiOpen = true;
        analyser = FindObjectOfType<SpectrumAnalyser>();
    }

    // Update is called once per frame
    void Update()
    {
        spectrum = analyser.SpectrumData();
    }

    public float[] GetSpectrum()
    {
        return spectrum;
    }

    public override void InteractToggle()
    {
        //The Spectrum Displayer is not interactable so we leave this blank
    }
}
