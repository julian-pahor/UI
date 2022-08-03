using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionUI : MonoBehaviour
{
    public Action action;

    [Header("Child Components")]
    public Image icon;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI descriptionTag;

    private void Start()
    {
        
    }

    public void SetAction(Action a)
    {
        if(a)
        {
            action = a;
        }
        

        if(nameTag)
        {
            nameTag.text = action.actionName;
        }

        if(descriptionTag)
        {
            descriptionTag.text = action.description;
        }
        if (icon)
        {
            icon.sprite = action.icon;
            icon.color = action.color;
        }
    }

    Player player;

    public void Init(Player p)
    {
        // store the player ref for use in our lambda function below 
        player = p;
        // find the button wherever we've placed it in the prefab 
        // for more complicated types of prefabs with multiple buttons, we'd make 
        //this a public member
        // and hook it up in the Unity editor 
        Button button = GetComponentInChildren<Button>(); 
        if (button)
        {
            button.onClick.AddListener(() => { player.DoAction(action); });
        }
            
    }

}
