using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_GridContainer : MonoBehaviour
{
    public Jar_Grid[] grids;
    public Transform[] gridOrigins;
    public string[] gridNames;
    public int gridWidth, gridHeight, cellSize, laneCount;
    public bool showDebug;
    public Jar_GridCell[][] playerSpawnCells;

    private void Start()
    {
        //Create Lanes
        grids = new Jar_Grid[laneCount];
        for (int i = 0; i < grids.Length; i++)
        {
            grids[i] = new Jar_Grid(i, gridWidth, gridHeight, cellSize, gridOrigins[i].position, gridNames[i], this);
        }

        //Assign SpawnCells
        playerSpawnCells = new Jar_GridCell[2][];
        playerSpawnCells[0] = new Jar_GridCell[3];
        playerSpawnCells[1] = new Jar_GridCell[3];

        for (int i = 0; i < 3; i++)
        {
            playerSpawnCells[0][i] = grids[i].GetCell(0, 0);
        }

        for (int i = 0; i < 3; i++)
        {
            playerSpawnCells[1][i] = grids[i].GetCell(gridWidth - 1, 0);
        }
    }
}