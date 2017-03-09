using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DaleranGames.UI
{
    public class MainMenuManager : MonoBehaviour
    {

        public int FirstScene = 1;

        private void Start()
        {
            GameInput.Instance.ContinueEvent += OnContinueKey;
            GameInput.Instance.QuitEvent += OnQuitKey;
        }

        private void OnDestroy()
        {
            GameInput.Instance.ContinueEvent -= OnContinueKey;
            GameInput.Instance.QuitEvent -= OnQuitKey;
        }

        public void OnContinueKey()
        {
            SceneManager.LoadScene(FirstScene);
        }

        public void OnQuitKey()
        {
            Application.Quit();
        }


    }

}