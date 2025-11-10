using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Search;
using UnityEngine;







public class Inventory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameManager gameManager;

    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
    }

    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
    }

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem("Generic Item");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem("Generic Item");
        }
    }
    */
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            items.Add(collisionItem.name);

            Destroy(collisionItem.gameObject);

            Debug.Log("Collected "+ collisionItem.name);
        }
    }
}
