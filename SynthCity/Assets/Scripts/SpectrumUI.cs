using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrumUI : MonoBehaviour
{
    public Spectrum spectrum;
    public SpectrumBar bar;
    public Material[] colors;

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
        barChildren = new SpectrumBar[spectrumData.Length];
        height = rt.rect.height;

        int j = 0;

        for(int i = 0; i < spectrumData.Length - 1; i++)
        {
            
            if(i % 4 == 0)
            {
                clone = Instantiate(bar, this.transform);
                barChildren[j] = clone;
                clone.GetComponent<Image>().material = colors[Random.Range(0, colors.Length - 1)];
                j++;
            }
            
        }
    }

    void Update()
    {
        spectrumData = spectrum.GetSpectrum();

        for (int i = 0; i < barChildren.Length - 1; i++)
        {
            barData = spectrumData[i] + spectrumData[i + 1] + spectrumData[i + 2] + spectrumData[i + 3];
            barData /= 4;
            barData = Mathf.Clamp(((Mathf.Log(barData) * 35) + (height * 1.2f)), 0, height);
            barChildren[i].SetTarget(barData);
        }
    }
}
