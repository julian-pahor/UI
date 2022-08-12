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

    private StarterAssets.FirstPersonController gameController;
    private StarterAssets.StarterAssetsInputs gameInputs;

    private void Start()
    {
        SetAllChildrenInactive();

        gameController = player.GetComponent<StarterAssets.FirstPersonController>();
        gameInputs = gameController.input();

        button1.onClick.AddListener(delegate { SpawnModule(module1); });
        button2.onClick.AddListener(delegate { SpawnModule(module2); });
        button3.onClick.AddListener(delegate { SpawnModule(module3); });
        button4.onClick.AddListener(delegate { SpawnModule(module4); });
        button5.onClick.AddListener(delegate { SpawnModule(module5); });
        button6.onClick.AddListener(delegate { SpawnModule(module6); });

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


        ////Only Y value matters, scroll forward = 120, backwards = -120
        //Debug.Log("Scroll.x = " + gameInputs.scroll.x + " Scroll.y = " + gameInputs.scroll.y);

        if(gameInputs.click)
        {
            Place();
            gameInputs.click = false;
        }
            
    }

    public void SpawnModule(GameObject module)
    {
        SetAllChildrenInactive();
        Vector3 rayStart = player.transform.position;
        rayStart.y = gameController.height * 0.8f;

        Ray ray = new Ray(rayStart, gameController.mainCamera().transform.forward);
        Vector3 offset = ray.GetPoint(4);
        
        if(module.GetComponent<Module>() != null)
        {
            clone = Instantiate(module.GetComponent<Module>().wireFrame, offset, player.transform.rotation, gameController.mainCamera().transform);
            placing = true;
            currentModule = module;
            
        }
        else
        {
            Debug.Log("GameObject to instantiate was not a Module Object!");
        }

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
