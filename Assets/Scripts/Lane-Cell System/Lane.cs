using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane
{
    //public GameObject laneGO;
    private Cell[] cells;

    private int length;
    private float cellSize;
    private int index;
    private Vector3 origin;
    private string laneName;
    private LaneContainer parentContainer;

    public Lane(int index, int length, float cellSize, Vector3 origin, string laneName, LaneContainer parentContainer)
    {
        Debug.Log("Lane " + index + " Init Start");
        this.index = index;
        this.length = length;
        this.cellSize = cellSize;
        this.origin = origin;
        this.laneName = laneName;
        this.parentContainer = parentContainer;
        cells = new Cell[length];
        for (int i = 0; i < length; i++)
        {
            cells[i] = new Cell(this, i, GetWorldPosition(i, GridAnchor.Center));
        }
        Debug.Log("Lane " + index + " Init Complete");
    }

    public Cell GetCell(int i)
    {
        if (i >= 0 && i < length)
        {
            return cells[i];
        }
        else
        {
            return default;
        }
    }

    public Cell[] GetCells()
    {
        return cells;
    }

    public int Index
    {
        get
        {
            return index;
        }
        set
        {
            index = value;
        }
    }

    public string LaneName
    {
        get
        {
            return laneName;
        }
        set
        {
            laneName = value;
        }
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

    public Vector3 GetWorldPosition(int i, GridAnchor gridAnchor)
    {
        switch (gridAnchor)
        {
            case (GridAnchor.BottomLeft):
                return (new Vector3(i, 0) * cellSize + origin);

            case (GridAnchor.Bottom):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize * 0.5f, 0);

            case (GridAnchor.BottomRight):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize, 0);

            case (GridAnchor.Left):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(0, cellSize * 0.5f);

            case (GridAnchor.Center):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize * 0.5f, cellSize * 0.5f);

            case (GridAnchor.Right):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize, cellSize * 0.5f);

            case (GridAnchor.TopLeft):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(0, cellSize);

            case (GridAnchor.Top):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize * 0.5f, cellSize);

            case (GridAnchor.TopRight):
                return (new Vector3(i, 0) * cellSize + origin) + new Vector3(cellSize, cellSize);

            default:
                return (new Vector3(i, 0) * cellSize + origin);
        }
    }

    public Vector3 GetWorldPosition(int i)
    {
        return GetWorldPosition(i, GridAnchor.Center);
    }
}