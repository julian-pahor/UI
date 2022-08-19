using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavyScale : MonoBehaviour
{
    RectTransform rt;
    private Vector3 wavy = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        //References for the RectTransform is obtained at initialisation 
        rt = GetComponent<RectTransform>();

        //Initialises local scale to default
        rt.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        //Uses Sin functions to make the gameobject bounce on the screen
        wavy.x = Mathf.Abs(Mathf.Sin(Time.time * 2f) * 0.5f) + 0.5f;
        wavy.y = Mathf.Abs(Mathf.Sin(Time.time * 2f) * 0.5f) + 0.5f;

        rt.localScale = wavy;
    }
}
