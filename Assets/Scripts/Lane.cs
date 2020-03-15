using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lane
{
<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
    private GameObject[,] inhabitants;
=======
    bool showDebug;
    public Jar_GridCell[,] gridCellArray;
    int width, height;
    float cellSize;
    Vector3 origin;
    public string gridName;
    public Jar_GridContainer parentContainer;
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs

    private int width, height;
    private float cellSize;
    private Vector3 origin;


<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
    public Lane(int w, int h, float cellSize, Transform parent, Vector3 origin)
=======
    public Jar_Grid(int w, int h, float cellSize, Vector3 origin, string gridName, Jar_GridContainer parentContainer)
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs
    {
        width = w;
        height = h;
        this.cellSize = cellSize;
        this.origin = origin;
<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
        inhabitants = new GameObject[width, height];
=======
        this.gridName = gridName;
        this.parentContainer = parentContainer;
        gridCellArray = new Jar_GridCell[width, height];
        spawnCells[0] = gridCellArray[0, height / 2];
        spawnCells[1] = gridCellArray[width-1, height / 2];
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs

        bool showDebug = true;
        if (showDebug)
        {
            for (int x = 0; x < inhabitants.GetLength(0); x++)
            {
<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
                for (int y = 0; y < inhabitants.GetLength(1); y++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
=======
                gridCellArray[x, y] = new Jar_GridCell();
                gridCellArray[x, y].SetCellIndex(x, y);
                gridCellArray[x, y].SetWorldPosition( GetWorldPosition(x, y, GridAnchor.Center) );
                gridCellArray[x, y].SetParentGrid(this);
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

<<<<<<< Updated upstream:Assets/Scripts/Lane.cs

        }
    }
=======
    }


>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs


    public Vector3 GetWorldPosition(int x, int y, GridAnchor gridAnchor)
    {
        switch (gridAnchor)
        {
            case (GridAnchor.BottomLeft):
                return (new Vector3(x, y) * cellSize + origin);
            case (GridAnchor.Bottom):
                return (new Vector3(x, y) * cellSize + origin) + new Vector3(cellSize*0.5f,0);
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
        return (new Vector3(x, y) * cellSize + origin);
    }


    public void MoveInhabitantToNextCell(UnitStateController controller)
    {
<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
        inhabitants[controller.gridPosX, controller.gridPosY] = null;
        inhabitants[controller.gridPosX + (1 * controller.GetPlayerDirection()), controller.gridPosY] = controller.gameObject;
        controller.gridPosX += 1 * controller.GetPlayerDirection();
=======
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridCellArray[x, y].AddObject(objectToAdd);
        }
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs
    }

    public bool CheckForInhabitant(int x, int y, out UnitStateController controller)
    {
        Debug.Log(x + ",   " + y);
        if (inhabitants[x, y] == null)
        {
            controller = null;
            return false;
        }
        else
        {
            controller = inhabitants[x, y].GetComponent<UnitStateController>();
            return true;
        }
    }

<<<<<<< Updated upstream:Assets/Scripts/Lane.cs
    public bool CheckNextCellForInhabitant(UnitStateController checkingController, out UnitStateController detectedController)
=======
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

                    if(checkX >= 0 && checkX < width && checkY >= 0 && checkY < height)
                    {
                        neighbours.Add(gridCellArray[checkX, checkY]);
                    }
                    
                }
            }
        }

        return neighbours;

    }


    public void MoveObject(int originalX, int originalY, int newX, int newY, UnitStateController controller)
>>>>>>> Stashed changes:Assets/Scripts/Grid System/Jar_Grid.cs
    {
        return CheckForInhabitant(checkingController.gridPosX + (1 * checkingController.GetPlayerDirection()), checkingController.gridPosY, out detectedController);
    }


    public void SetInhabitant(int x, int y, GameObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            inhabitants[x, y] = value;
            inhabitants[x, y].transform.position = GetWorldPosition(x, y);
        }
    }


    public GameObject GetInhabitant(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return inhabitants[x, y];
        }
        else
        {
            return default;
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
}
