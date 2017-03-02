using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DaleranGames.ElectricDreams
{
    public class MainMenuManager : MonoBehaviour
    {

        public int FirstScene = 1;

        private void OnEnable()
        {
            GameInput.Instance.ContinueEvent += OnContinueKey;
            GameInput.Instance.QuitEvent += OnQuitKey;
        }

        private void OnDisable()
        {
            GameInput.Instance.ContinueEvent -= OnContinueKey;
            GameInput.Instance.QuitEvent -= OnQuitKey;
        }

        public void OnContinueKey()
        {
            GameInput.Instance.ContinueEvent -= OnContinueKey;
            GameInput.Instance.QuitEvent -= OnQuitKey;
            SceneManager.LoadScene(FirstScene);
        }

        public void OnQuitKey()
        {
            GameInput.Instance.ContinueEvent -= OnContinueKey;
            GameInput.Instance.QuitEvent -= OnQuitKey;
            Application.Quit();
        }


    }

}