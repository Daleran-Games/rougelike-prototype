using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames;

namespace DaleranGames.UI
{
    public class HelpPanel : MonoBehaviour
    {

        private void Awake()
        {

            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameMenu.StateEnabled += OnEnterMenuState;
                GameManager.Instance.GameMenu.StateDisabled += OnExitMenuState;
                gameObject.SetActive(false); 
            }
            else
                gameObject.SetActive(true);
        }


        private void OnDestroy()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameMenu.StateEnabled -= OnEnterMenuState;
                GameManager.Instance.GameMenu.StateDisabled -= OnExitMenuState;
            }
        }

        void OnEnterMenuState(GameState newState)
        {
            gameObject.SetActive(true);
        }

        void OnExitMenuState(GameState newState)
        {
            gameObject.SetActive(false);
        }

    } 
}
