using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit : MonoBehaviour
{
    string spawnString;
    public List<Char> spawnChars;
    StringGenerator strGen;
    Transform lane;
    GameObject type;
    int level;

    public QueuedUnit(Transform lane, GameObject type, int level)
    {
        this.lane = lane;
        this.type = type;
        this.level = level;
        spawnString = strGen.CalculateSpawnString(this.level);
        spawnChars = new List<Char>();
        
    }
    
    public GameObject SpawnUnit()
    {
        return Instantiate(type, lane.position, Quaternion.identity);
    }
}
