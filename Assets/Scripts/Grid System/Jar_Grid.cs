using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jar_Grid
{
    private bool showDebug;
    private Jar_GridCell[,] gridCellArray;
    private int width, height;
    private float cellSize;
    private int gridIndex;
    private Vector3 origin;
    private string gridName;
    private Jar_GridContainer parentContainer;

    public Jar_Grid(int index, int w, int h, float cellSize, Vector3 origin, string gridName, Jar_GridContainer parentContainer)
    {
        gridIndex = index;
        width = w;
        height = h;
        this.cellSize = cellSize;
        this.origin = origin;
        this.gridName = gridName;
        this.parentContainer = parentContainer;
        gridCellArray = new Jar_GridCell[width, height];

        for (int x = 0; x < gridCellArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridCellArray.GetLength(1); y++)
            {
                bool endCell = false;

                if (x == 0 || x == w - 1)
                {
                    endCell = true;
                }
                else
                {
                    endCell = false;
                }

                gridCellArray[x, y] = new Jar_GridCell(this, x, y, GetWorldPosition(x, y, GridAnchor.Center), endCell);
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y, GridAnchor gridAnchor)
    {
        switch (gridAnchor)
        {
            case (GridAnchor.BottomLeft):
                return (new Vector3(x, y) * cellSize + origin);

            case (GridAnchor.Bottom):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize * 0.5f, 0);

            case (GridAnchor.BottomRight):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize, 0);

            case (GridAnchor.Left):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(0, cellSize * 0.5f);

            case (GridAnchor.Center):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize * 0.5f, cellSize * 0.5f);

            case (GridAnchor.Right):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize, cellSize * 0.5f);

            case (GridAnchor.TopLeft):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(0, cellSize);

            case (GridAnchor.Top):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize * 0.5f, cellSize);

            case (GridAnchor.TopRight):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize, cellSize);

            default:
                return (new Vector3(x, y) * cellSize + origin);
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return GetWorldPosition(x, y, GridAnchor.Center);
    }

    public void AddUnit(int x, int y, UnitStateController unit)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            unit.GetCurrentCell().RemoveUnit();
            unit.SetCurrentCell(gridCellArray[x, y]);
        }
    }

    public UnitStateController GetUnit(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridCellArray[x, y].GetUnit();
        }
        else
        {
            return default;
        }
    }

    public Jar_GridCell GetCell(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridCellArray[x, y];
        }
        else
        {
            return default;
        }
    }

    public Jar_GridCell[,] GetAllCells()
    {
        return gridCellArray;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GridIndex
    {
        get
        {
            return gridIndex;
        }
        set
        {
            gridIndex = value;
        }
    }

    public string GridName
    {
        get
        {
            return gridName;
        }
        set
        {
            gridName = value;
        }
    }

    //public UnitStateController GetUnit(Vector3 worldPosition)
    //{
    //    int x, y;
    //    x = Mathf.RoundToInt((worldPosition.x / cellSize) - origin.x);
    //    y = Mathf.RoundToInt((worldPosition.y / cellSize) - origin.y);
    //    return GetUnit(x, y);
    //}

    public enum GridAnchor
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight,
    }
}