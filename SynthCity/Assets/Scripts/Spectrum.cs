using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : Module
{
    //This is the actual object being spawned by the ModuleMaker

    public SpectrumAnalyser analyser;
    float[] spectrum = new float[256];

    private void Start()
    {
        //Since this object is purely visual and has no interactive UI it sets its uiOpen to always be true and therefore not interactable
        uiOpen = true;
        
        analyser = FindObjectOfType<SpectrumAnalyser>();
    }

    // Update is called once per frame
    void Update()
    {
        spectrum = analyser.SpectrumData();
    }

    //This function is used to pass the spectrum data to the UIclass which uses it to move the bars in the visualiser
    public float[] GetSpectrum()
    {
        return spectrum;
    }

    public override void InteractToggle()
    {
        //Must be declared for its Base class
        //The Spectrum Displayer is not interactable so we leave this blank
    }
}
