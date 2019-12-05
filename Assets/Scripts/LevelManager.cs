using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelSizeX;
    public int levelSizeY;
    public int cellSize;
    private iGrid levelGrid;
    void Awake()
    {
        levelGrid = new iGrid(levelSizeX, levelSizeY, cellSize);
    }

    public void InstantiateOnGrid(int x, int y, GameObject obj)
    {
        Vector3 spawnLocation = levelGrid.GetCellPosition(x, y);
        Debug.Log(spawnLocation);
        Instantiate(obj, spawnLocation, Quaternion.identity);
    }
}
