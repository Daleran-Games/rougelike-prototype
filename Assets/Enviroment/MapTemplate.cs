using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

namespace DaleranGames.World
{
    [CreateAssetMenu(fileName = "NewMapTemplate", menuName = "Data/Map Template", order = 100)]
    [AdvancedInspector(true)]
    public class MapTemplate : ScriptableObject
    {

        [Header("Map Size")]
        public Vector2Int NumberOfCoulmns = new Vector2Int(8, 10);
        public Vector2Int NumberOfRows = new Vector2Int(8, 10);

        [Header("Background Tiles")]
        public GameObject backgroundBase;
        public Color32 backgroundColor = Color.black;
        public GameObject[] backgroundDetails;
        [Range(0f, 1f)]
        public float backgroundDetailChance = 0.25f;

        [Header("Resource Tiles")]
        public GameObject[] structureTiles;
        public Vector2Int structureCount = new Vector2Int(2, 4);
        public GameObject[] plantTiles;
        public Vector2Int plantCount = new Vector2Int(2, 7);
        public GameObject[] energyTiles;
        public Vector2Int energyCount = new Vector2Int(1, 4);

        [Header("Enemies")]
        public GameObject[] enemies;

        [Header("Primary Tiles")]
        public GameObject primaryBase;
        public GameObject[] primaryDetails;
        [Range(0f, 1f)]
        public float primaryDetailChance = 0.25f;
        [Space(10)]
        public GameObject[] nwPrimaryTiles;
        public GameObject[] nPrimaryTiles;
        public GameObject[] nePrimaryTiles;
        public GameObject[] wPrimaryTiles;
        public GameObject[] ePrimaryTiles;
        public GameObject[] swPrimaryTiles;
        public GameObject[] sPrimaryTiles;
        public GameObject[] sePrimaryTiles;

        [Header("Secondary Tiles")]
        public GameObject secondaryBase;
        public GameObject[] secondaryDetails;
        [Range(0f, 1f)]
        public float secondaryDetailChance = 0.25f;
        [Space(10)]
        public GameObject[] nwSecondaryTiles;
        public GameObject[] nSecondaryTiles;
        public GameObject[] neSecondaryTiles;
        public GameObject[] wSecondaryTiles;
        public GameObject[] eSecondaryTiles;
        public GameObject[] swSecondaryTiles;
        public GameObject[] sSecondaryTiles;
        public GameObject[] seSecondaryTiles;

        [Header("Bridge Tiles")]
        public GameObject northBridge;
        public GameObject southBridge;
        public GameObject bridgeBase;
        [Range(1, 14)]
        public int bridgeLength = 5;

        [Header("Road Tiles")]
        public GameObject roadBase;
        public GameObject[] roadDetails;
        [Range(0f, 1f)]
        public float roadDetailChance = 0.25f;

        public MapData GenerateNewMap(int level)
        {
            return new MapData(Random.Range(NumberOfCoulmns.x, NumberOfCoulmns.y), Random.Range(NumberOfRows.x, NumberOfRows.y), this, level);
        }

    } 
}
