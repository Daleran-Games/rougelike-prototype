using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DalLib;

public delegate void StateChangeHandler(GameState state);

public class GameManager : MonoBehaviour {

    protected GameManager() { }
    public static GameManager Instance = null;


    #region PersistentData
    private SaveData save;
    public SaveData Save
    {
        get { return save; }
        set { save = value; }
    }

    [SerializeField]
    private ConfigSettings config;
    public ConfigSettings Config
    {
        get { return config; }
        set { config = value; }
    }
    #endregion

    #region StateMachine

    public event StateChangeHandler ChangedState;

    private GameState currentState;
    public GameState CurrentState
    {
        get { return currentState; }
        private set { currentState = value; }
    }

    private GameMenuState gameMenu;
    public GameMenuState GameMenu
    {
        get { return gameMenu; }
        private set { gameMenu = value; }
    }

    private LoadSceneState loadScene;
    public LoadSceneState LoadScene
    {
        get { return loadScene; }
        private set { loadScene = value; }
    }

    private PlayState play;
    public PlayState Play
    {
        get { return play; }
        private set { play = value; }
    }

    private GameOverState gameOver;
    public GameOverState GameOver
    {
        get { return gameOver; }
        private set { gameOver = value; }
    }

    #endregion

    // Use this for initialization
    void Awake ()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        GameMenu = gameObject.GetOrAddComponent<GameMenuState>();
        LoadScene = gameObject.GetOrAddComponent<LoadSceneState>();
        Play = gameObject.GetOrAddComponent<PlayState>();
        GameOver = gameObject.GetOrAddComponent<GameOverState>();

        CurrentState = LoadScene;

        LoadScene.enabled = false;
        GameMenu.enabled = false;
        Play.enabled = false;
        GameOver.enabled = false;

        Save = gameObject.GetOrAddComponent<SaveData>();

        if (Config == null)
            Debug.LogError("DG ERROR: No Config File Attached");

	}

    private void OnEnable()
    {
        LoadScene.StateDisabled += OnCompleteLoadScene;
        Play.PlayerDieEvent += OnPlayerDeath;
        Play.PlayerExitEvent += OnPlayerExitPlay;
        Play.RequestMenuEvent += OnRequestMenu;
        GameMenu.StateDisabled += OnReturnToGame;
        GameOver.StateDisabled += OnCompleteGameOver;

        CurrentState.enabled = true;
    }

    private void Start()
    {
        if (ChangedState != null)
            ChangedState(CurrentState);

        Debug.Log("Transitioning to: " + CurrentState.GetType().ToString());
    }

    private void OnDestroy()
    {
        LoadScene.StateDisabled -= OnCompleteLoadScene;
        Play.PlayerDieEvent -= OnPlayerDeath;
        Play.PlayerExitEvent -= OnPlayerExitPlay;
        Play.RequestMenuEvent -= OnRequestMenu;
        GameMenu.StateDisabled -= OnReturnToGame;
        GameOver.StateDisabled -= OnCompleteGameOver;
    }

    void ChangeState(GameState newState)
    {
        CurrentState.enabled = false;
        CurrentState = newState;
        CurrentState.enabled = true;

        if (ChangedState != null)
            ChangedState(newState);

        Debug.Log("Transitioning to: " + newState.GetType().ToString());
    }

    void OnCompleteLoadScene(GameState newState)
    {
        ChangeState(Play);
    }

    void OnPlayerExitPlay (GameState newState)
    {
        Debug.Log("Game Manager Recieved Exit Request");
        ChangeState(LoadScene);
        SceneManager.LoadScene(1);

    }

    void OnPlayerDeath (GameState newState)
    {
        ChangeState(GameOver);
    }

    void OnRequestMenu (GameState newState)
    {
        ChangeState(GameMenu);
    }

    void OnReturnToGame (GameState newState)
    {
        ChangeState(Play);
    }

    void OnCompleteGameOver (GameState newState)
    {
        ChangeState(LoadScene);
        SceneManager.LoadScene(1);
    }




}
