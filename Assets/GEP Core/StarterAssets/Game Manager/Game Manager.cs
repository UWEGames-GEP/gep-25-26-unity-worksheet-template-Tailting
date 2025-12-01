using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        GAMEPLAY,
        PAUSE
    }

    public GameState state = GameState.GAMEPLAY;
    private bool hasChangedState = false;

    void Update()
    {
        // No more GetKeyDown — use Input System callback instead
    }

    public void TogglePause()
    {
        if (state == GameState.GAMEPLAY)
        {
            state = GameState.PAUSE;
        }
        else
        {
            state = GameState.GAMEPLAY;
        }

        hasChangedState = true;
    }

    private void LateUpdate()
    {
        if (!hasChangedState) return;

        hasChangedState = false;

        switch (state)
        {
            case GameState.GAMEPLAY:
                Time.timeScale = 1f;
                break;

            case GameState.PAUSE:
                Time.timeScale = 0f;
                break;
        }
    }
}
