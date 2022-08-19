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

    private float scaler;

    private void Start()
    {
        rt = this.GetComponent<RectTransform>();
        image = this.GetComponent<Image>();
        targetVector = rt.sizeDelta;
    }
    void Update()
    {
        
        targetVector.y = targetY;
        scaler = targetY / 300;
        rt.sizeDelta = Vector2.SmoothDamp(rt.sizeDelta, targetVector, ref velocity, smoothTime);

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
        

        //Debug.Log(targetY);
    }

    public void SetTarget(float target)
    {
        if(target > 0)
        {
            targetY = target;
        }
        
    }
}
