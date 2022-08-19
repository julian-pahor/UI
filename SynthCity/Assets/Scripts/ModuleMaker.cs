using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class ModuleMaker : MonoBehaviour
{
    public GameObject module1;
    public GameObject module2;
    public GameObject module3;
    public GameObject module4;
    public GameObject module5;
    public GameObject module6;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    public GameObject player;

    private GameObject clone;
    private GameObject currentModule;

    public bool online = false;

    private bool placing;
    public GameObject placementUI;

    private StarterAssets.FirstPersonController gameController;
    private StarterAssets.StarterAssetsInputs gameInputs;

    private void Start()
    {
        //Sets all children innactive in order to hide the UI from the screen
        SetAllChildrenInactive();

        //Gains reference to the player controller for the input
        gameController = player.GetComponent<StarterAssets.FirstPersonController>();
        gameInputs = gameController.input();

        //Creates functions for each button, attaching a module to spawn for each individual button
        button1.onClick.AddListener(delegate { SpawnModule(module1); });
        button2.onClick.AddListener(delegate { SpawnModule(module2); });
        button3.onClick.AddListener(delegate { SpawnModule(module3); });
        button4.onClick.AddListener(delegate { SpawnModule(module4); });
        button5.onClick.AddListener(delegate { SpawnModule(module5); });
        button6.onClick.AddListener(delegate { SpawnModule(module6); });

        //Fills in button text with the name of the module 
        if(button1.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button1.GetComponentInChildren<TextMeshProUGUI>().text = module1.name;
        }
        if (button2.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button2.GetComponentInChildren<TextMeshProUGUI>().text = module2.name;
        }
        if (button3.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button3.GetComponentInChildren<TextMeshProUGUI>().text = module3.name;
        }
        if (button4.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button4.GetComponentInChildren<TextMeshProUGUI>().text = module4.name;
        }
        if (button5.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button5.GetComponentInChildren<TextMeshProUGUI>().text = module5.name;
        }
        if (button6.GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            button6.GetComponentInChildren<TextMeshProUGUI>().text = module6.name;
        }
    }

    private void Update()
    {
        //While setting the position of object to spawn it enables a tooltip for player controls refrence
        if(placing)
        {
            placementUI.SetActive(true);
        }
        else
        {
            placementUI.SetActive(false);
        }

        //Uses the scrollwheel input to change the distance of the object being placed
        if(clone != null)
        {
            float distance = Vector3.Distance(clone.transform.position, player.transform.position);
            if (distance > 4 && distance < 20)
            {
                if (gameInputs.scroll.y > 0)
                {
                    clone.transform.position += gameController.mainCamera().transform.forward / 2f;
                }
                else if (gameInputs.scroll.y < 0)
                {
                    clone.transform.position -= gameController.mainCamera().transform.forward / 2f;
                }
            }
            else if(distance < 4)
            {
                clone.transform.position += gameController.mainCamera().transform.forward;
            }
            else if(distance > 20)
            {
                clone.transform.position -= gameController.mainCamera().transform.forward;
            }
            
        }

        //If the input reads a click it finalises the placement of a module
        if(gameInputs.click)
        {
            Place();
            gameInputs.click = false;
        }
            
    }

    public void SpawnModule(GameObject module)
    {
        //Function called by pressing a button on the UI
        //Sets the UI to inactive so players can see the screen
        SetAllChildrenInactive();

        //uses a ray to position a spawned wireframe, so as the player can see physically where the module will be placed 
        Vector3 rayStart = player.transform.position;
        rayStart.y = gameController.height * 0.8f;

        Ray ray = new Ray(rayStart, gameController.mainCamera().transform.forward);
        Vector3 offset = ray.GetPoint(4);
        
        if(module.GetComponent<Module>() != null)
        {
            //Creates the Modules wireframe and enables the placing flag 
            clone = Instantiate(module.GetComponent<Module>().wireFrame, offset, player.transform.rotation, gameController.mainCamera().transform);
            placing = true;
            currentModule = module;
            
        }
        else
        {
            Debug.Log("GameObject to instantiate was not a Module Object!");
        }

        //Turns off the mouse so that players regain "look" control
        gameController.MouseToggle();

    }

    public void SetAllChildrenInactive()
    {
        
        foreach(Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        online = false;
    }

    public void SetAllChildrenActive()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
        }
        online = true;
    }

    public void Place()
    {
        //Creates the real module in place of the wireframe and destroys the wireframe that was existing to show placement position
        if(placing && currentModule != null)
        {
            Instantiate(currentModule, clone.transform.position, clone.transform.rotation);
            Destroy(clone);
            clone = null;
            currentModule = null;
            placing = false;
        }
    }

    public void ToggleClose()
    {
        SetAllChildrenInactive();
        gameController.MouseToggle();
    }


}
