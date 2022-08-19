using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumAnalyser : MonoBehaviour
{
    private float[] spectrum = new float[256];

    // Update is called once per frame
    void Update()
    {
        //SpectrumAnalyser is used to only have one GameObject calling the GetSpectrumData as it's quite expensive and shouldnt be called by multiple objects
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
    }

    //Function used to pass around the found data
    public float[] SpectrumData()
    {
        return spectrum;
    }
}
