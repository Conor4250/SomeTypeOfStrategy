using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lane
{
    private GameObject[,] inhabitants;

    private int width, height;
    private float cellSize;
    private Vector3 origin;


    public Lane(int w, int h, float cellSize, Transform parent, Vector3 origin)
    {
        width = w;
        height = h;
        this.cellSize = cellSize;
        this.origin = origin;
        inhabitants = new GameObject[width, height];

        bool showDebug = true;
        if (showDebug)
        {
            for (int x = 0; x < inhabitants.GetLength(0); x++)
            {
                for (int y = 0; y < inhabitants.GetLength(1); y++)
                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);


        }
    }


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
        inhabitants[controller.gridPosX, controller.gridPosY] = null;
        inhabitants[controller.gridPosX + (1 * controller.GetPlayerDirection()), controller.gridPosY] = controller.gameObject;
        controller.gridPosX += 1 * controller.GetPlayerDirection();
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

    public bool CheckNextCellForInhabitant(UnitStateController checkingController, out UnitStateController detectedController)
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
