using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderEditor : MonoBehaviour
{
    [Header("Components")]
    public Slider slider;
    public TMP_InputField input;
    public string formatS = "NULL";
    public bool changing;
    
    //Used for a prebuilt Slider prefab, provides a good foundation for multiple different UI's to use it
    public void DragBegin()
    {
        changing = true;
    }

    public void DragEnd()
    {
        changing = false;
    }
}
