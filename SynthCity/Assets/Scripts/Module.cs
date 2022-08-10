using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    public GameObject UI;
    public bool uiOpen;
    public abstract void InteractToggle();
}
