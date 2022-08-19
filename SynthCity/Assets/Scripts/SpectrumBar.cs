using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrumBar : MonoBehaviour
{
    public Material lowMat;
    public Material midMat;
    public Material highMat;

    private float targetY;
    private Vector2 targetVector;

    private RectTransform rt;
    private Image image;
    private Vector2 velocity = Vector2.zero;
    private float smoothTime = 0.1f;

    private void Start()
    {
        //References to the Rect transform and image component are gotten when this object is instantiated
        rt = this.GetComponent<RectTransform>();
        image = this.GetComponent<Image>();
        
        //intialises target vector to initial size of bar
        targetVector = rt.sizeDelta;
    }
    void Update()
    {
        //targetY is updated by the spectrum data and used to set Y of the vector to smooth towards
        targetVector.y = targetY;
        
        //Smooths the bars height towards the desired height - smoothTime is set in global variables
        rt.sizeDelta = Vector2.SmoothDamp(rt.sizeDelta, targetVector, ref velocity, smoothTime);

        //Changes colour of the bar based off of current height (read through targetY)
        if(targetY > 240)
        {
            image.material = highMat;
        }
        else if(targetY > 170)
        {
            image.material = midMat;
        }
        else
        {
            image.material = lowMat;
        }
    }

    //Function used by SpectrumUI class to pass spectrum data
    public void SetTarget(float target)
    {
        if(target > 0)
        {
            targetY = target;
        }
        
    }
}
