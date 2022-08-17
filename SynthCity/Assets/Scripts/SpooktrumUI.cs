using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpooktrumUI : MonoBehaviour
{
    public Spooktrum spook;
    public GameObject bar;
    public Material[] colors;

    private float[] spectrumData = new float[256];
    private RectTransform rt;
    private float height;

    // Start is called before the first frame update
    void Start()
    {
        rt = this.GetComponent<RectTransform>();
        height = rt.rect.height;
        for(int i = 0; i < spectrumData.Length - 1; i++)
        {
            Instantiate(bar, this.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        spectrumData = spook.GetSpectrum();

        for(int i = 0;i < spectrumData.Length - 1;i++)
        {
            RectTransform childRT = this.gameObject.transform.GetChild(i).GetComponent<RectTransform>();
            childRT.sizeDelta = new Vector2(childRT.sizeDelta.x, (Mathf.Log(spectrumData[i]) * -25));
        }
        
    }
}
