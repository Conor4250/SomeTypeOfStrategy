using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneContainer : MonoBehaviour
{
    //public GameObject lanePrefab;
    //public GameObject cellPrefab;
    public Lane[] lanes;

    public Transform[] laneOrigins;
    private string[] laneNames;
    public int cellCount, cellSize, laneCount;
    private bool finishedLoading = false;

    private void Start()
    {
        Debug.Log("LaneContainer Init Start");
        lanes = new Lane[laneCount];
        laneNames = new string[laneCount];

        for (int i = 0; i < laneCount; i++)
        {
            laneNames[i] = laneOrigins[i].name;
            lanes[i] = new Lane(i, cellCount, cellSize, laneOrigins[i].position, laneNames[i], this);
        }

        //for (int l = 0; l < laneCount; l++)
        //{
        //    var laneGO = Instantiate(lanePrefab, laneOrigins[l].position, Quaternion.identity, gameObject.transform);
        //    laneGO.name = laneNames[l];
        //    laneGO.transform.localScale = new Vector3(cellSize * cellCount + 1, cellSize + 1, 1);
        //    lanes[l].laneGO = laneGO;

        //    for (int c = 0; c < cellCount; c++)
        //    {
        //        var cellGO = Instantiate(lanePrefab, lanes[l].GetCell(c).GetWorldPosition(), Quaternion.identity, laneGO.transform);
        //        cellGO.name = lanes[l].GetCell(c).index.ToString();
        //        cellGO.transform.localScale = new Vector3(cellSize, cellSize, 1);
        //        lanes[l].GetCell(c).cellGO = cellGO;
        //    }
        //}

        finishedLoading = true;
        Debug.Log("LaneContainer Init Complete");
    }

    private void OnDrawGizmos()
    {
        if (finishedLoading == true)
        {
            for (int i = 0; i < laneCount; i++)
            {
                for (int j = 0; j < cellCount; j++)
                {
                    Gizmos.DrawCube(lanes[i].GetCell(j).GetWorldPosition(), new Vector3(cellSize * 0.8f, cellSize * 0.8f));
                }
            }
        }
    }
}