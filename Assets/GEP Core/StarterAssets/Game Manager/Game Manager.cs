using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Android;

public class Game : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum GameState
    {
        GAMEPLAY,
        PAUSE
    }

    public GameState state;
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
            }
        }
        else if (state == GameState.PAUSE)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = GameState.GAMEPLAY;
            }
        }
    }
}
