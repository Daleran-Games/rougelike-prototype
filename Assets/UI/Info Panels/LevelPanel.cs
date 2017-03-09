using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DaleranGames;

namespace DaleranGames.UI
{
    public class LevelPanel : MonoBehaviour
    {

        public Text levelText;
        SaveData save;

        private void Awake()
        {
            levelText = GetComponentInChildren<Text>();

            if (levelText == null)
                Debug.LogError("DG ERROR: No text component on level panel");

            save = GameManager.Instance.Save;
            GameManager.Instance.LoadScene.StateEnabled += OnBeginLevelLoading;
            GameManager.Instance.LoadScene.StateDisabled += OnHideScreen;
            GameManager.Instance.GameOver.StateEnabled += OnGameOver;
            GameManager.Instance.GameOver.StateDisabled += OnHideScreen;

        }

        private void Start()
        {
            levelText.text = "System Loading: Zone " + save.SavedZone + Environment.NewLine + Environment.NewLine + "*  Initiating sensors: 0028:C0034B23" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Load success. Standby for initialization _";
        }

        private void OnEnable()
        {

        }

        private void OnDestroy()
        {
            GameManager.Instance.LoadScene.StateEnabled -= OnBeginLevelLoading;
            GameManager.Instance.LoadScene.StateDisabled -= OnHideScreen;
            GameManager.Instance.GameOver.StateEnabled -= OnGameOver;
            GameManager.Instance.GameOver.StateDisabled -= OnHideScreen;

        }

        public void OnBeginLevelLoading(GameState newState)
        {
            levelText.text = "System Loading: Zone " + save.SavedZone + Environment.NewLine + Environment.NewLine + "*  Initiating sensors: 0028:C0034B23" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Load success. Standby for initialization _";
            gameObject.SetActive(true);
        }

        public void OnHideScreen(GameState newState)
        {
            gameObject.SetActive(false);
        }

        public void OnGameOver(GameState newState)
        {
            gameObject.SetActive(true);
            levelText.text = "A fatal exception has occurred at zone " + save.SavedZone + ". The current application will be terminated." + Environment.NewLine + Environment.NewLine + "*  Unable to load kernal." + Environment.NewLine + "*  Hardware fault located at 0031:D0014F09" + Environment.NewLine + "*  Saving sytem logs: " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine + "Press Space to continue or ESC to terminate _";
        }



    } 
}
