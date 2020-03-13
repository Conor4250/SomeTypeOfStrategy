using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneContainer : MonoBehaviour
{
    public Lane[] lanes;
    public Transform[] laneTransforms;
    public int laneHeight, laneWidth, cellSize, laneCount;

    void Start()
    {
        lanes = new Lane[laneCount];
        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = new Lane(laneWidth, laneHeight, cellSize, gameObject.transform, laneTransforms[i].position);
        }
        
    }

    //Add a unit to a lane and initialise it
    
        
        
}
