using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneState : GameState
{

    SaveData save;
    ConfigSettings config;

    BoardManager gameWorld;

    private void Awake()
    {
        gameWorld = GameManager.Instance.gameObject.GetRequiredComponent<BoardManager>();
    }

    void OnEnable()
    {
        save = GameManager.Instance.Save;
        config = GameManager.Instance.Config;
        save.SavedZone++;
        InitializeGame();

        if (StateEnabled != null)
            StateEnabled(this);
    }


    private void OnDisable()
    {

    }

    void InitializeGame ()
    {
        Invoke("FinishedLoading", config.LevelStartDelay);
        gameWorld.SetupScene(save.SavedZone);
    }

    void FinishedLoading ()
    {
        if (StateEnabled != null)
            StateDisabled(this);
    }
}
