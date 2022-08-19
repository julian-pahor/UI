using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{
    //Module acts as a base abstract class for all Modules that can be spawned into the world
    //It enforces all the standard functionality the object would need to function

    public GameObject UI;
    public GameObject wireFrame;
    public bool uiOpen;
    public abstract void InteractToggle();
}
