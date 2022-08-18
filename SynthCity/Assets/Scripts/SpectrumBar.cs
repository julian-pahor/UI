using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpectrumBar : MonoBehaviour
{
    private float targetY;
    private Vector2 targetVector;

    private RectTransform rt;
    private Vector2 velocity = Vector2.zero;
    private float smoothTime = 0.1f;

    private void Start()
    {
        rt = this.GetComponent<RectTransform>();
        targetVector = rt.sizeDelta;
    }
    void Update()
    {
        targetVector.y = targetY;
        rt.sizeDelta = Vector2.SmoothDamp(rt.sizeDelta, targetVector, ref velocity, smoothTime);
        Debug.Log(targetY);
    }

    public void SetTarget(float target)
    {
        if(target > 0)
        {
            targetY = target;
        }
        
    }
}
