using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public string spawnString;
    public List<Char> spawnChars;


    public int player;
    public Jar_Grid grid;
    public GameObject unitPrefab;
    

    public QueuedUnit(int player, Jar_Grid grid, GameObject unitPrefab)
    {
        this.player = player;
        this.grid = grid;
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
