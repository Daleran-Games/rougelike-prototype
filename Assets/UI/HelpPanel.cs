using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class HelpPanel : MonoBehaviour
    {

        private void Awake()
        {
            GameManager.Instance.GameMenu.StateEnabled += OnEnterMenuState;
            GameManager.Instance.GameMenu.StateDisabled += OnExitMenuState;
            gameObject.SetActive(false);
        }


        private void OnDestroy()
        {
            GameManager.Instance.GameMenu.StateEnabled -= OnEnterMenuState;
            GameManager.Instance.GameMenu.StateDisabled -= OnExitMenuState;
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
