using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iGrid
{
    private int width;
    private int height;
    private int cellSize;
    private int[,] gridArray;

    public iGrid(int width, int height, int cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        //for (int x = 0; x < gridArray.GetLength(0); x++)
        //    for (int y = 0; y < gridArray.GetLength(1); y++)
        //    {
        //        do stuff;
        //    }
    }

    public Vector3 GetCellPosition(int x, int y)
    {
        Debug.Log(x * cellSize + (cellSize / 2));
        Debug.Log(0);
        Debug.Log(y * cellSize + (cellSize / 2));
        return new Vector3(x*cellSize+(cellSize/2),0,y*cellSize + (cellSize / 2));
    }

    
}
