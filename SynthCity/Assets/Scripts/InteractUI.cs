using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{

    public void Toggle(bool toggle)
    {
        gameObject.SetActive(toggle);
    }
}
