using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DalLib;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public BoardManager GameBoard;
    public int PlayerFoodPoints = 100;
    [HideInInspector]
    public bool playersTurn = true;

    int level = 3;
    protected GameManager() { }

	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
        GameBoard = gameObject.GetRequiredComponent<BoardManager>();
        InitGame();
	}

    private void InitGame()
    {
        GameBoard.SetupScene(level);
    }

    public void GameOver()
    {
        enabled = false;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
