using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DalLib;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager gameBoard;
    public PlayerSave playerSave;
    public AudioClip gameOverSound;
    public float turnDelay = 0.1f;
    public float levelStartDelay = 2f;

    [HideInInspector]
    public bool playersTurn = true;

    UIManager ui;
    int zone = 0;
    public int Zone
    {
        get { return zone; }
        private set { zone = value; }
    }

    bool enemiesMoving;
    bool doingSetup = true;
    List<Enemy> enemies;
    public List<Enemy> Enemies
    {
        get { return enemies; }
        private set { enemies = value; }
    }



	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
        enemies = new List<Enemy>();
        gameBoard = gameObject.GetRequiredComponent<BoardManager>();
        playerSave = gameObject.GetRequiredComponent<PlayerSave>();

	}

    void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode)
    {
        Zone++;
        InitGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    private void InitGame()
    {
        doingSetup = true;

        ui = GameObject.Find("UICanvas").GetRequiredComponent<UIManager>();

        ui.SetUpUI();

        if (Zone > 1)
            SetTutorialState(false);

        Invoke("OnFinishedLevelSetup", levelStartDelay);

        enemies.Clear();
        gameBoard.SetupScene(Zone);
    }

    void OnFinishedLevelSetup()
    {
        ui.HideLevelScreen();
        doingSetup = false;
    }

    public void GameOver()
    {
        ui.ShowGameOverScreen();
        enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (playersTurn || enemiesMoving || doingSetup)
        {
            return;
        }

        StartCoroutine(MoveEnemies());
	}

    public void SetTutorialState (bool state)
    {
        ui.SetTutorialScreen(state);
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }

    public void RemoveEnemyFromList (Enemy script)
    {
        enemies.Remove(script);
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);
        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i <enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(turnDelay);
        }

        playersTurn = true;
        enemiesMoving = false;

    }
}
