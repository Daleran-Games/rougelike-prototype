using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapData
{
    MapTemplate template;
    int level;

    int columns;
    public int Columns
    {
        get { return columns; }
        private set { columns = value; }
    }

    int rows;
    public int Rows
    {
        get { return rows; }
        private set { rows = value; }
    }

    GameObject[,] terrainTiles;
    public GameObject[,] TerrainTiles
    {
        get { return terrainTiles; }
        private set { terrainTiles = value; }
    }

    GameObject[,] objectTiles;
    public GameObject[,] ObjectTiles
    {
        get { return objectTiles; }
        private set { objectTiles = value; }
    }

    Vector2Int entrancePosition;
    public Vector2Int EntrancePosition
    {
        get { return entrancePosition; }
        private set { entrancePosition = value; }
    }
    Vector2Int exitPosition;
    public Vector2Int ExitPosition
    {
        get { return exitPosition; }
        private set { exitPosition = value; }
    }

    List<Vector2Int> gridPositions = new List<Vector2Int>();


    public MapData (int columns, int rows, MapTemplate template, int level)
    {
        Columns = columns;
        Rows = rows;
        this.template = template;
        this.level = level;

        TerrainTiles = new GameObject[columns + 4, rows + 4];
        ObjectTiles = new GameObject[columns + 4, rows + 4];
        
        BuildBasicTerrain();
        PlaceExitAndBridge();
        LayoutObjectsAlongPath(template.roadBase, template.roadDetails, template.roadDetailChance, new Vector2Int(EntrancePosition.x, EntrancePosition.y + 1), ExitPosition);
        InitializeGridPositions();
        LayoutObjectsAtRandom(template.structureTiles,template.structureCount.x, template.structureCount.y);
        LayoutObjectsAtRandom(template.plantTiles, template.plantCount.x, template.plantCount.y);
        LayoutObjectsAtRandom(template.energyTiles, template.energyCount.x, template.energyCount.y);
        int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObjectsAtRandom(template.enemies, enemyCount, enemyCount);
    }

    void InitializeGridPositions ()
    {
        gridPositions.Clear();

        for (int x = 2; x <= Columns + 1; x++)
        {
            for (int y = 2; y <= Rows + 1; y++)
            {
                if (ObjectTiles[x,y] == null)
                    gridPositions.Add(new Vector2Int(x, y));
            }
        }
    }

    Vector2Int RandomGridPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector2Int randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void RemoveGridPosition (Vector2Int pos)
    {
        for (int i=0; i < gridPositions.Count; i++)
        {
            if (gridPositions[i] == pos)
                gridPositions.RemoveAt(i);
        }
    }

    void LayoutObjectsAtRandom(GameObject[] tileArray, int min, int max)
    {
        int objectCount = Random.Range(min, max + 1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector2Int randomPosition = RandomGridPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            ObjectTiles[randomPosition.x, randomPosition.y] = tileChoice;
        }
    }

    void LayoutObjectsAlongPath(GameObject baseTile, GameObject[] detailTiles, float detailChance, Vector2Int startPoint, Vector2Int endPoint)
    {
        Vector2Int currentPos = startPoint;
        //Debug.Log("Starting road at " + currentPos + " to " + endPoint);
        bool goUp = true;

        do
        {

            ObjectTiles[currentPos.x, currentPos.y] = PickTile(baseTile, detailTiles, detailChance);
            //Debug.Log("Adding road at " + currentPos);
            RemoveGridPosition(currentPos);

            if (currentPos.x != endPoint.x)
            {
                if (goUp == true)
                {
                    currentPos.y++;
                    goUp = false;
                }
                else
                {
                    if (currentPos.x < endPoint.x)
                        currentPos.x++;
                    else
                        currentPos.x--;

                    goUp = true;
                }
            }
            else
            {
                currentPos.y++;
            }

        } while (currentPos != endPoint) ;
    }

    GameObject PickTile(GameObject baseTile, GameObject[] detailTiles, float detailChance)
    {
        float clampedChance = Mathf.Clamp01(detailChance);
        bool detailsExist = (detailTiles != null && detailTiles.Length > 0) ? true : false;

        if (detailsExist && Random.value < detailChance)
        {
            return detailTiles[Random.Range(0, detailTiles.Length)];
        }

        return baseTile;
    }

    void BuildBasicTerrain()
    {
        for (int x = 0; x <= Columns + 3; x++)
        {
            for (int y = 0; y <= Rows + 3; y++)
            {
                //Layout background tiles
                if (x==0 || y == 0 || x == Columns+3 || y == Rows +3)
                {
                    TerrainTiles[x, y] = PickTile(template.backgroundBase, template.backgroundDetails, template.backgroundDetailChance);
                }
                //Southwest corner tiles
                else if (x==1 && y == 1)
                {
                    TerrainTiles[x, y] = template.swPrimaryTiles[Random.Range(0, template.swPrimaryTiles.Length)];
                }
                //West tiles
                else if (y > 1 && y < Rows + 2 && x == 1)
                {
                    TerrainTiles[x, y] = template.wPrimaryTiles[Random.Range(0, template.wPrimaryTiles.Length)];
                }
                //Northwest corner tiles
                else if (y == Rows + 2 && x == 1)
                {
                    TerrainTiles[x, y] = template.nwPrimaryTiles[Random.Range(0, template.nwPrimaryTiles.Length)];
                }
                //North tiles
                else if (x > 1 && x < Columns+2 && y == Rows + 2)
                {
                    TerrainTiles[x, y] = template.nPrimaryTiles[Random.Range(0, template.nPrimaryTiles.Length)];
                }
                //Northeast corner tiles
                else if ( x == Columns + 2 && y == Rows + 2)
                {
                    TerrainTiles[x, y] = template.nePrimaryTiles[Random.Range(0, template.nePrimaryTiles.Length)];
                } 
                //East tiles
                else if (x == Columns + 2 && y < Rows +2 && y > 1)
                {
                    TerrainTiles[x, y] = template.ePrimaryTiles[Random.Range(0, template.ePrimaryTiles.Length)];
                }
                //Southeast corner tiles
                else if ( x== Columns + 2 && y == 1)
                {
                    TerrainTiles[x, y] = template.sePrimaryTiles[Random.Range(0, template.sePrimaryTiles.Length)];
                }
                //South tiles
                else if ( x < Columns +2 && x > 1 && y == 1)
                {
                    TerrainTiles[x, y] = template.sPrimaryTiles[Random.Range(0, template.sPrimaryTiles.Length)];
                }
                //Layout basic terrain tiles
                else
                {
                    TerrainTiles[x, y] = PickTile(template.primaryBase, template.primaryDetails, template.primaryDetailChance);
                }

            }
        }
    }

    void PlaceExitAndBridge()
    {
        //Place Entrance
        int randEntranceX = Random.Range(2, Columns + 1);
        TerrainTiles[randEntranceX, 1] = null;
        ObjectTiles[randEntranceX, 1] = template.southBridge;
        EntrancePosition = new Vector2Int(randEntranceX, 1);

        //Place Exit
        int randExitX = Random.Range(2, Columns + 1);
        TerrainTiles[randExitX, Rows + 2] = null;
        ObjectTiles[randExitX, Rows + 2] = template.northBridge;
        ExitPosition = new Vector2Int(randExitX, Rows + 2);

    }


}
