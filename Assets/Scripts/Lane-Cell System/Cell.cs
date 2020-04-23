using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Lane parent;
    public int index;
    private UnitBrain occupyingUnit;
    public bool isProtected, containsUnit = false;
    private Vector3 worldPosition;

    public Cell(Lane parent, int index, Vector3 worldPosition)
    {
        this.parent = parent;
        this.index = index;
        this.worldPosition = worldPosition;
        occupyingUnit = null;
    }

    public UnitBrain GetUnit()
    {
        if (containsUnit)
        {
            return occupyingUnit;
        }
        else
        {
            return default;
        }
    }

    public void SetUnit(UnitBrain unit)
    {
        occupyingUnit = unit;
        containsUnit = true;
    }

    public void RemoveUnit()
    {
        occupyingUnit = null;
        containsUnit = false;
    }

    public Vector3 GetWorldPosition()
    {
        return worldPosition;
    }
}