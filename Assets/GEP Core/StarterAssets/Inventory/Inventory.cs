using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.Search;
using UnityEngine;
using static GameManager;


public class Inventory : MonoBehaviour
{
    public GameManager gameManager;

    // Parent transform for instantiated world items
    private Transform worldItemsParent;

    // List of collected items
    public List<ItemObject> items = new List<ItemObject>();

    void Start()
    {
        // Automatically find the GameManager
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager == null)
            {
                Debug.LogWarning("GameManager not found in scene!");
            }
        }

        // Find and cache the "World Items" transform
        GameObject worldItemsObject = GameObject.Find("World Items");
        if (worldItemsObject != null)
        {
            worldItemsParent = worldItemsObject.GetComponent<Transform>();
        }
        else
        {
            Debug.LogWarning("World Items object not found in scene!");
        }
    }

    // Adds an item to the inventory
    public void AddItem(ItemObject item)
    {
        items.Add(item);
        Debug.Log(item.itemName + " added to inventory.");
    }

    // Removes a specific item (kept for reference)
    public void RemoveItem(ItemObject item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemName + " removed from inventory.");
        }
        else
        {
            Debug.Log(item.itemName + " not found in inventory.");
        }
    }

    // NEW OVERLOAD: Removes the first item in the list and spawns it in the world
    public void RemoveItem()
    {
        // Ensure we are in gameplay and have items to drop
        if (gameManager != null && gameManager.state == GameManager.GameState.GAMEPLAY && items.Count > 0)
        {
            // Get the first item in the inventory
            ItemObject itemToDrop = items[0];

            // Get player position and rotation
            Vector3 playerPos = transform.position;
            Quaternion playerRot = transform.rotation;

            // Position the item slightly in front of the player
            Vector3 spawnPos = playerPos + transform.forward;

            // Rotate the item to face the player (180° on Y-axis)
            Quaternion spawnRot = playerRot * Quaternion.Euler(0f, 180f, 0f);

            // Instantiate a new copy of the item’s GameObject in the world
            GameObject newItem = Instantiate(itemToDrop.gameObject, spawnPos, spawnRot, worldItemsParent);

            // Reactivate it (since original was inactive)
            newItem.SetActive(true);

            Debug.Log("Dropped: " + itemToDrop.itemName);

            // Remove it from the inventory
            items.RemoveAt(0);

            // Destroy the original item reference
            Destroy(itemToDrop.gameObject);
        }
    }

    // Called when CharacterController collides with an ItemObject
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ItemObject collisionItem = hit.gameObject.GetComponent<ItemObject>();

        if (collisionItem != null)
        {
            // Add to inventory
            AddItem(collisionItem);

            // Deactivate item in the world (don’t destroy)
            collisionItem.gameObject.SetActive(false);

            Debug.Log("Picked up: " + collisionItem.itemName);
        }
    }
}