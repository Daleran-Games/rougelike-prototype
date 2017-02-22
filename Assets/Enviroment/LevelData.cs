using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Data/Level Data", order = 100)]
public class LevelData : ScriptableObject
{

    [System.Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count scrapCount = new Count(2, 4);
    public Count plantCount = new Count(2, 7);
    public Count energyCount = new Count(1, 4);


    public GameObject[] backgroundTiles;
    public GameObject[] nwTiles;
    public GameObject[] nTiles;
    public GameObject[] neTiles;
    public GameObject[] eTiles;
    public GameObject[] seTiles;
    public GameObject[] sTiles;
    public GameObject[] swTiles;
    public GameObject[] wTiles;
    public GameObject[] floorTiles;
    public GameObject[] exitTiles;
    public GameObject[] roadTiles;

    
    public GameObject[] scrapTiles;
    public GameObject[] plantTiles;
    public GameObject[] energyTiles;

    public GameObject[] enemies;

    
}
