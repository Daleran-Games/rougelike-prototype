using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuState : GameState
{


    private void OnEnable()
    {
        if (StateEnabled != null)
            StateEnabled(this);

        GameInput.Instance.QuitEvent += OnQuitGameKey;
        GameInput.Instance.MenuEvent += OnResumeGame;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = GameManager.Instance.Save.SlowTimeScale;
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.MenuEvent -= OnResumeGame;
    }

    void OnQuitGameKey()
    {
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.MenuEvent -= OnResumeGame;
        Application.Quit();
    }

    void OnResumeGame()
    {
        if (StateEnabled != null)
            StateDisabled(this);
    }


}
