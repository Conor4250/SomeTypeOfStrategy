using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jar_Grid
{
    private bool showDebug;
    public Jar_GridCell[,] gridCellArray;
    private int width, height;
    private float cellSize;
    private Vector3 origin;
    public string gridName;
    public Jar_GridContainer parentContainer;

    public Jar_Grid(int w, int h, float cellSize, Vector3 origin, string gridName, Jar_GridContainer parentContainer)
    {
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
                gridCellArray[x, y] = new Jar_GridCell();
                gridCellArray[x, y].SetCellIndex(x, y);
                gridCellArray[x, y].SetWorldPosition(GetWorldPosition(x, y, GridAnchor.Center));
                gridCellArray[x, y].SetParentGrid(this);
            }
        }
    }

    public Jar_GridCell GetCell(int x, int y)
    {
        return gridCellArray[x, y];
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

    public void AddObject(int x, int y, GameObject objectToAdd)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridCellArray[x, y].AddObject(objectToAdd);
        }
    }

    public List<GameObject> GetCellObjects(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridCellArray[x, y].GetObjects();
        }
        else
        {
            return default;
        }
    }

    public List<GameObject> GetCellObjects(Vector3 worldPosition)
    {
        int x, y;
        x = Mathf.RoundToInt((worldPosition.x / cellSize) - origin.x);
        y = Mathf.RoundToInt((worldPosition.y / cellSize) - origin.y);
        return GetCellObjects(x, y);
    }

    public List<Jar_GridCell> GetNeighbours(Jar_GridCell cell)
    {
        List<Jar_GridCell> neighbours = new List<Jar_GridCell>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }
                else
                {
                    int checkX = cell.cellIndexX + x;
                    int checkY = cell.cellIndexY + y;

                    if (checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                    {
                        neighbours.Add(gridCellArray[checkX, checkY]);
                    }
                }
            }
        }

        return neighbours;
    }

    public void MoveObject(int originalX, int originalY, int newX, int newY, UnitStateController controller)
    {
        if (originalX >= 0 && originalY >= 0 && newX >= 0 && newY >= 0 && originalX < width && originalY < height && newX < width && newY < height)
        {
            foreach (GameObject cellObject in gridCellArray[originalX, originalY].GetObjects())
            {
            }
        }
    }

    public void SetShowDebug(bool showDebug)
    {
        this.showDebug = showDebug;
    }

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