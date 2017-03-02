using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DaleranGames.ElectricDreams
{
    public class LoadSceneState : GameState
    {

        SaveData save;
        ConfigSettings config;

        BoardManager gameWorld;

        private void Awake()
        {
            gameWorld = GameManager.Instance.gameObject.GetRequiredComponent<BoardManager>();
            save = GameManager.Instance.Save;
            config = GameManager.Instance.Config;
            SceneManager.sceneLoaded += OnSceneFinishedLoading;
        }


        void OnEnable()
        {

            Invoke("FinishedLoading", config.LevelStartDelay);

            if (StateEnabled != null)
                StateEnabled(this);
        }


        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneFinishedLoading;
        }


        void FinishedLoading()
        {
            if (StateEnabled != null)
                StateDisabled(this);
        }

        void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            save.SavedZone++;
            gameWorld.SetupScene(save.SavedZone);
        }
    } 
}
