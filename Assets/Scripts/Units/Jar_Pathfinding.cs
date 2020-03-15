using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Jar_Pathfinding
{

    Jar_Grid grid;


    public Jar_Pathfinding(Jar_Grid grid)
    {
        this.grid = grid;
    }

    void FindPath(int startPosX, int startPosY, int targetPosX, int targetPosY)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Jar_GridCell startingCell = grid.gridCellArray[startPosX, startPosY];
        Jar_GridCell targetCell = grid.gridCellArray[targetPosX, targetPosY];

        Jar_Heap<Jar_GridCell> openSet = new Jar_Heap<Jar_GridCell>(grid.gridCellArray.Length);
        HashSet<Jar_GridCell> closedSet = new HashSet<Jar_GridCell>();

        openSet.Add(startingCell);

        while (openSet.Count > 0)
        {
            Jar_GridCell currentCell = openSet.RemoveFirstItem();
            closedSet.Add(currentCell);

            if (currentCell == targetCell)
            {
                sw.Stop();
                UnityEngine.Debug.Log("Path found: " + sw.ElapsedMilliseconds + " ms");
                RetracePathway(startingCell, targetCell);
                return;
            }
            
            foreach (Jar_GridCell neighbour in grid.GetNeighbours(currentCell))
            {
                if (!neighbour.walkable || neighbour.containsEntity || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newMovementCostToNeighbour = currentCell.gCost + GetDistance(currentCell, neighbour);
                if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetCell);
                    neighbour.parentCell = currentCell;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }

            }
        }
    }


    void RetracePathway(Jar_GridCell startCell, Jar_GridCell endCell)
    {
        List<Jar_GridCell> path = new List<Jar_GridCell>();
        Jar_GridCell currentNode = endCell;

        while (currentNode != startCell)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentCell;
        }
        path.Reverse();

        grid.parentContainer.path = path;
    }

    int GetDistance(Jar_GridCell cellA, Jar_GridCell cellB)
    {
        int distanceX = Mathf.Abs(cellA.cellIndexX - cellB.cellIndexX);
        int distanceY = Mathf.Abs(cellA.cellIndexY - cellB.cellIndexY);
        if (distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }
        else
        {
            return 14 * distanceX + 10 * (distanceY - distanceX);
        }
    }
}
