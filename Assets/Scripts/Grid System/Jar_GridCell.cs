using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_GridCell : IHeapItem<Jar_GridCell>
{
    Jar_Grid parentGrid;

    public int cellIndexX, cellIndexY;
        
    List<GameObject> cellGameObjects;
    public bool containsEntity = false;

    public int gCost, hCost;
    public Jar_GridCell parentCell;
    public bool walkable = true;
    Vector3 worldPosition;
    int heapIndex;


    public Jar_GridCell()
    {
        cellGameObjects = new List<GameObject>();
        cellIndexX = cellIndexY = 0;
    }

    public void AddObject(GameObject objectToAdd)
    {
        cellGameObjects.Add(objectToAdd);
        containsEntity = true;
    }

    public void RemoveObject(GameObject objectToRemove)
    {
        cellGameObjects.Remove(objectToRemove);
        if (cellGameObjects.Count == 0)
            containsEntity = false;
    }

    public List<GameObject> GetObjects() 
    {
        return cellGameObjects;
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

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Jar_GridCell cellToCompare)
    {
        int compare = fCost.CompareTo(cellToCompare.fCost);
        if(compare == 0)
        {
            compare = hCost.CompareTo(cellToCompare.hCost);
        }
        return -compare;
    }

}
