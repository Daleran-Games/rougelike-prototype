using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : GameState
{

    private void OnEnable()
    {
        if (StateEnabled != null)
            StateEnabled(this);

        GameInput.Instance.QuitEvent += OnQuitGameKey;
        GameInput.Instance.MenuEvent += OnRestartGame;
    }

    private void OnDisable()
    {
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.MenuEvent -= OnRestartGame;
    }

    void OnQuitGameKey ()
    {
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.MenuEvent -= OnRestartGame;
        Application.Quit();
    }

    void OnRestartGame()
    {
        if (StateEnabled != null)
            StateDisabled(this);
    }


}
