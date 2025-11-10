using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using StarterAssets;
using System;
using UnityEditor.Search;

public class PlayerCharacterController : ThirdPersonController
{

    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("PauseGame");
        }
    }

    private void OnRemoveItem(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("Remove Item");
            GetComponent<Inventory>().RemoveItem();
        }
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
