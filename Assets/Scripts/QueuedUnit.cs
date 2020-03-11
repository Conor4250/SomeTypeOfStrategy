using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public string spawnString;
    public LaneContainer laneContainer;
    public List<Char> spawnChars;
    public int laneIndex;
    public GameObject unitPrefab;
    public int player;

    public QueuedUnit(int player, int laneIndex, GameObject unitPrefab, LaneContainer laneContainer)
    {
        this.laneContainer = laneContainer;
        this.player = player;
        this.laneIndex = laneIndex;
        this.unitPrefab = unitPrefab;
        

        StringGenerator strGen = new StringGenerator(player);
        spawnString = strGen.CalculateSpawnString(3);

        spawnChars = new List<Char>();
        foreach (char c in spawnString)
        {
            spawnChars.Add(c);
        }
        
    }


    
}
