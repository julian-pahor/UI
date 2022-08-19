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
        rt = GetComponent<RectTransform>();

        rt.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        wavy.x = Mathf.Abs(Mathf.Sin(Time.time * 2f) * 0.5f) + 0.5f;
        wavy.y = Mathf.Abs(Mathf.Sin(Time.time * 2f) * 0.5f) + 0.5f;

        rt.localScale = wavy;
    }
}
