using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeController : MonoBehaviour
{
    private float pitchmax = 1.5f;
    private float pitchmin = 0.5f;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if(audioSource.pitch < pitchmax)
            {
                audioSource.pitch += 0.0003f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (audioSource.pitch > pitchmin)
            {
                audioSource.pitch -= 0.0003f;
            }
        }
        else if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (audioSource.pitch > 1)
            {
                audioSource.pitch -= 0.001f;
            }
            else if (audioSource.pitch < 1)
            {
                audioSource.pitch += 0.001f;
            }
        }  
    }
}
