using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_GridCell
{
    private Jar_Grid parentGrid;
    public int cellIndexX, cellIndexY;
    private UnitStateController unit;
    private bool containsUnit = false;
    private bool endCell = false;

    private Vector3 worldPosition;

    public Jar_GridCell(Jar_Grid parentGrid, int x, int y, Vector3 worldPosition, bool endCell)
    {
        this.parentGrid = parentGrid;
        this.worldPosition = worldPosition;
        cellIndexX = x;
        cellIndexY = y;
        this.endCell = endCell;
    }

    public bool AddUnit(UnitStateController unit)
    {
        if (!containsUnit)
        {
            this.unit = unit;
            containsUnit = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveUnit()
    {
        if (containsUnit)
        {
            unit = null;
            containsUnit = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Contains(UnitStateController unit)
    {
        if (this.unit == unit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //public void SetEndCell(bool isEndCell)
    //{
    //    this.isEndCell = isEndCell;
    //}

    public bool GetEndCell()
    {
        return endCell;
    }

    public bool ContainsUnit()
    {
        return containsUnit;
    }

    public Jar_GridCell GetNeighbourCell(int directionX)
    {
        return parentGrid.GetCell(cellIndexX + directionX, cellIndexX);
    }

    public UnitStateController GetUnit()
    {
        return unit;
    }

    public Vector3 GetWorldPosition()
    {
        return worldPosition;
    }
}