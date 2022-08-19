using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrumUI : MonoBehaviour
{
    public Spectrum spectrum;
    public SpectrumBar bar;

    public float smoothTime = 0.3f;

    private float[] spectrumData = new float[256];
    private RectTransform rt;
    private float height;
    private float barData;
    private SpectrumBar clone;
    private SpectrumBar[] barChildren;
    private Vector2 initialP, endP;
    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        barChildren = new SpectrumBar[spectrumData.Length / 4];
        height = rt.rect.height;

        int j = 0;

        //Creates all the bars needed for spectrum data to be passed to
        for(int i = 0; i < spectrumData.Length - 1; i++)
        {
            
            if(i % 4 == 0) //creating 4 times less bars than amount of individual pieces of spectrum data
            {
                clone = Instantiate(bar, this.transform);
                barChildren[j] = clone; //Adds the created bars to the bar array
                clone = null;
                j++;
            }
            
        }
    }

    void Update()
    {
        spectrumData = spectrum.GetSpectrum();

        for (int i = 0; i < barChildren.Length - 1; i++)
        {
            //Averages the spectrum data in groups of 4 to pass to each bar
            barData = spectrumData[i] + spectrumData[i + 1] + spectrumData[i + 2] + spectrumData[i + 3];
            barData /= 4;
            //Actual data coming out of data is exceptionally small so we use Log to normalises to a appropriate level based off of size values in the rect transform
            barData = Mathf.Clamp(((Mathf.Log(barData) * 35) + (height * 1.2f)), 0, height);
            barChildren[i].SetTarget(barData);
        }
    }
}
