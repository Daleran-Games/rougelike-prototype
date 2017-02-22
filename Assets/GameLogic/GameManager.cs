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
    public int startingEnergy = 100;
    public float turnDelay = 0.1f;
    public float levelStartDelay = 2f;
    [HideInInspector]
    public bool playersTurn = true;


    Text levelText;
    GameObject levelImage;
    int level = 0;
    List<Enemy> enemies;
    bool enemiesMoving;
    bool doingSetup = true;

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
	}

    void OnLevelFinishedLoading (Scene scene, LoadSceneMode mode)
    {
        level++;
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
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetRequiredComponent<Text>();
        levelText.text = "Day " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);

        enemies.Clear();
        gameBoard.SetupScene(level);
    }

    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    public void GameOver()
    {
        levelText.text = "After " + level + " days, you starved.";
        levelImage.SetActive(true);
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

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
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
            yield return new WaitForSeconds(enemies[i].MoveTime);
        }

        playersTurn = true;
        enemiesMoving = false;

    }
}
