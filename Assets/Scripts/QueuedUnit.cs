using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public string spawnString;
    public List<Char> spawnChars;
    public int laneInt;
    public Transform lane;
    public GameObject type;
    public int level, player;

    public QueuedUnit(int player,Transform lane, int laneInt, GameObject type, int level)
    {

        this.player = player;
        this.lane = lane;
        this.laneInt = laneInt;
        this.type = type;
        this.level = level;
        StringGenerator strGen = new StringGenerator(player);
        spawnString = strGen.CalculateSpawnString(this.level);
        spawnChars = new List<Char>();
        foreach (char c in spawnString)
        {
            spawnChars.Add(c);
        }
        
    }


    
}
