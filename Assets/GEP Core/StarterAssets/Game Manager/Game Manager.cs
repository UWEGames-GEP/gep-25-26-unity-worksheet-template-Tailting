using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum GameState
    {
        GAMEPLAY,
        PAUSE
    }

    public GameState state;
    bool HasChangedState;

    void Start()
    {
        switch(state)
        {
            case GameState.GAMEPLAY:
                break;
            case GameState.PAUSE:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (state == GameState.GAMEPLAY)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.PAUSE;
                HasChangedState = true;
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.GAMEPLAY;
                HasChangedState = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (HasChangedState)
        {
            HasChangedState = false;

            if (state == GameState.GAMEPLAY)
            {
                Time.timeScale = 1.0f;
            }
            else if (state == GameState.PAUSE)
            {
                Time.timeScale = 0.0f;
            }
        }
    }

}
