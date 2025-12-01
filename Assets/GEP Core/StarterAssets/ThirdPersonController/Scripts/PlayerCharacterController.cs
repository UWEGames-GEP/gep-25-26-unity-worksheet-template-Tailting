using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PlayerCharacterController : ThirdPersonController
{
    [SerializeField] private GameManager manager;

    private void Start()
    {
        // If not assigned in Inspector, auto-find it
        if (manager == null)
            manager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        // We override camera locking HERE instead of modifying ThirdPersonController.
        if (manager != null)
        {
            LockCameraPosition = (manager.state == GameManager.GameState.PAUSE);
        }
    }

    // Called by the Input System for pause button
    private void OnPause(InputValue value)
    {
        if (value.isPressed)
        {
            manager?.TogglePause();
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
}
