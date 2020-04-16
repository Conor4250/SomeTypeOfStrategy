using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_GridCell
{
    public Jar_Grid parentGrid;
    public int cellIndexX, cellIndexY;
    public List<GameObject> cellObjects;
    public bool containsEntity = false;

    private Vector3 worldPosition;

    public Jar_GridCell()
    {
        cellObjects = new List<GameObject>();
        cellIndexX = cellIndexY = 0;
    }

    public void AddObject(GameObject objectToAdd)
    {
        cellObjects.Add(objectToAdd);
        containsEntity = true;
    }

    public void RemoveObject(GameObject objectToRemove)
    {
        cellObjects.Remove(objectToRemove);
        if (cellObjects.Count == 0)
            containsEntity = false;
    }

    public List<GameObject> GetObjects()
    {
        return cellObjects;
    }

    public void SetCellIndex(int x, int y)
    {
        cellIndexX = x;
        cellIndexY = y;
    }

    public void SetParentGrid(Jar_Grid parentGrid)
    {
        this.parentGrid = parentGrid;
    }

    public void SetWorldPosition(Vector3 worldPosition)
    {
        this.worldPosition = worldPosition;
    }

    public Vector3 GetWorldPosition()
    {
        return worldPosition;
    }
}