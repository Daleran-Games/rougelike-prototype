using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames
{
    public class GameMenuState : GameState
    {


        private void OnEnable()
        {
            if (StateEnabled != null)
                StateEnabled(this);

            GameInput.Instance.QuitEvent += OnQuitGameKey;
            GameInput.Instance.ContinueEvent += OnResumeGame;
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            Time.timeScale = GameManager.Instance.Save.SlowTimeScale;
            GameInput.Instance.QuitEvent -= OnQuitGameKey;
            GameInput.Instance.ContinueEvent -= OnResumeGame;
        }

        void OnQuitGameKey()
        {
            GameInput.Instance.QuitEvent -= OnQuitGameKey;
            GameInput.Instance.ContinueEvent -= OnResumeGame;
            Application.Quit();
        }

        void OnResumeGame()
        {
            Debug.Log("ResumingGame");

            if (StateDisabled != null)
                StateDisabled(this);
        }


    }

}