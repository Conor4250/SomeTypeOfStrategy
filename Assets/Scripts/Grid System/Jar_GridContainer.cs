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

    private void Start()
    {
        grids = new Jar_Grid[laneCount];
        for (int i = 0; i < grids.Length; i++)
        {
            grids[i] = new Jar_Grid(gridWidth, gridHeight, cellSize, gridOrigins[i].position, gridNames[i], this);
            grids[i].SetShowDebug(showDebug);
        }
    }

    private void OnDrawGizmos()
    {
        if (grids != null && showDebug == true)
        {
            foreach (Jar_Grid grid in grids)
            {
                if (grid != null)
                {
                    foreach (Jar_GridCell cell in grid.gridCellArray)
                    {
                        Gizmos.DrawCube(cell.GetWorldPosition(), new Vector3(cellSize - 0.1f, cellSize - 0.1f));
                    }
                }
            }
        }
    }
}