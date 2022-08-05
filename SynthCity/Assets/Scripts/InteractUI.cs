using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    public StarterAssets.FirstPersonController player;

    void Update()
    {
        Debug.Log(player.interactable);

        if (player != null)
        {
            this.gameObject.SetActive(player.interactable);
        }
    }
}
