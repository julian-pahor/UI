using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisclaimerFade : MonoBehaviour
{
    public bool toggleFade;
    RectTransform rt;

    public RectTransform enterText;

    private Vector3 wavyScale = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        if(!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
        }

        rt = this.gameObject.GetComponent<RectTransform>();

        rt.localScale = Vector3.one;

        toggleFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleFade)
        {
            rt.localScale += new Vector3(-0.003f, -0.003f, 1);

            if (rt.localScale.x <= 0f)
            {
                this.gameObject.SetActive(false);
            }
        }

        wavyScale.x = Mathf.Abs(Mathf.Sin(Time.time * 1.5f) * 1.2f);
        wavyScale.y = Mathf.Abs(Mathf.Sin(Time.time * 1.5f) * 1.2f);

        enterText.localScale = wavyScale;
    }

    public void ToggleFade()
    {
        toggleFade = true;
    }


}
