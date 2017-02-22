using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    /*
    [Serializable]
    public class Count
    {
        public int Minimum;
        public int Maximum;

        public Count (int min, int max)
        {
            Minimum = min;
            Maximum = max;
        }
    }

    public int Columns = 8;
    public int Rows = 8;
    public Count WallCount = new Count(5, 9);
    public Count FoodCount = new Count(1, 5);

    public GameObject Exit;
    public GameObject[] FloorTiles;
    public GameObject[] FoodTiles;
    public GameObject[] EnemyTiles;
    public GameObject[] WallTiles;
    public GameObject[] OuterWallTiles;
    */

    public LevelData levelData;

    Transform boardHolder;
    List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for (int x=1; x < levelData.columns-1; x++)
        {
            for (int y=1; y < levelData.rows -1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup ()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < levelData.columns + 1; x++)
        {
            for (int y=-1; y< levelData.rows +1; y++)
            {
                GameObject toInstatiate = levelData.floorTiles[Random.Range(0, levelData.floorTiles.Length)];

                if (x == -1 && y == -1)
                    toInstatiate = levelData.swTiles[Random.Range(0, levelData.swTiles.Length)];
                else if (x == -1 && y != levelData.rows)
                    toInstatiate = levelData.wTiles[Random.Range(0, levelData.wTiles.Length)];
                else if (x == -1 && y == levelData.rows)
                    toInstatiate = levelData.nwTiles[Random.Range(0, levelData.nwTiles.Length)];
                else if (y == levelData.rows && x != levelData.columns)
                    toInstatiate = levelData.nTiles[Random.Range(0, levelData.nTiles.Length)];
                else if (y == levelData.rows && x == levelData.columns)
                    toInstatiate = levelData.neTiles[Random.Range(0, levelData.neTiles.Length)];
                else if (x == levelData.columns && y!= -1)
                    toInstatiate = levelData.eTiles[Random.Range(0, levelData.eTiles.Length)];
                else if (x == levelData.columns && y == -1)
                    toInstatiate = levelData.seTiles[Random.Range(0, levelData.seTiles.Length)];
                else if (x > -1 && x < levelData.columns && y == -1)
                    toInstatiate = levelData.sTiles[Random.Range(0, levelData.sTiles.Length)];

                GameObject instance = Instantiate(toInstatiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectsAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i=0; i< objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene (int level)
    {
        BoardSetup();
        InitializeList();
        LayoutObjectsAtRandom(levelData.scrapTiles, levelData.scrapCount.minimum, levelData.scrapCount.maximum);
        LayoutObjectsAtRandom(levelData.plantTiles, levelData.plantCount.minimum, levelData.plantCount.maximum);
        LayoutObjectsAtRandom(levelData.energyTiles, levelData.energyCount.minimum, levelData.energyCount.maximum);
        int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectsAtRandom(levelData.enemies, enemyCount, enemyCount);
        Instantiate(levelData.exitTiles[Random.Range( 0, levelData.exitTiles.Length)], new Vector3(levelData.columns - 1, levelData.rows - 1, 0f),Quaternion.identity);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
