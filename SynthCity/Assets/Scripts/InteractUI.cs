using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    //Simple function being used to turn on and off this UI element
    public void Toggle(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
