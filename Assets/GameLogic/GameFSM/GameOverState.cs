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
        GameInput.Instance.ContinueEvent += OnRestartGame;
        SoundManager.Instance.RandomSFX(GameManager.Instance.Config.GameOverSound);
    }

    private void OnDisable()
    {
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.ContinueEvent -= OnRestartGame;
    }

    void OnQuitGameKey ()
    {
        GameInput.Instance.QuitEvent -= OnQuitGameKey;
        GameInput.Instance.ContinueEvent -= OnRestartGame;
        Application.Quit();
    }

    void OnRestartGame()
    {
        if (StateEnabled != null)
            StateDisabled(this);
    }


}
