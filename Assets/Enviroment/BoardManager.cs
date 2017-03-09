using System.Collections;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using UnityEngine;

namespace DaleranGames.World
{
    public class BoardManager : MonoBehaviour
    {


        public MapTemplate mapTemplate;

        MapData mapData;
        Transform terrain;
        Transform objects;
        List<Vector3> gridPositions = new List<Vector3>();

        public void SetupScene(int level)
        {
            terrain = new GameObject("TerrainTiles").transform;
            objects = new GameObject("ObjectTiles").transform;

            mapData = mapTemplate.GenerateNewMap(level);
            BuildMap(mapData);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(mapData.EntrancePosition.x, mapData.EntrancePosition.y, 0f);

        }

        void BuildMap(MapData md)
        {
            Camera.main.backgroundColor = mapTemplate.backgroundColor;


            for (int x = 0; x < md.Columns + 3; x++)
            {
                for (int y = 0; y < md.Rows + 3; y++)
                {
                    if (md.TerrainTiles[x, y] != null)
                    {
                        GameObject newTerrain = Instantiate(md.TerrainTiles[x, y], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                        newTerrain.transform.SetParent(terrain);
                    }

                    if (md.ObjectTiles[x, y] != null)
                    {
                        GameObject newObject = Instantiate(md.ObjectTiles[x, y], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                        newObject.transform.SetParent(objects);
                    }

                }
            }

            for (int y = 0; y > (0 - mapTemplate.bridgeLength); y--)
            {

                GameObject newObject = Instantiate(mapTemplate.bridgeBase, new Vector3(md.EntrancePosition.x, y, 0f), Quaternion.identity) as GameObject;
                newObject.transform.SetParent(objects);

            }

            for (int y = md.Rows + 3; y < (md.Rows + 3 + mapTemplate.bridgeLength); y++)
            {

                GameObject newObject = Instantiate(mapTemplate.bridgeBase, new Vector3(md.ExitPosition.x, y, 0f), Quaternion.identity) as GameObject;
                newObject.transform.SetParent(objects);

            }


        }


    } 
}
