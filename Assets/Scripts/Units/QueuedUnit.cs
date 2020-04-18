using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public Jar_Grid grid;
    public GameObject unitPrefab;
    public PlayerManager playerManager;

    public string spawnString;
    public List<Char> spawnChars;

    public QueuedUnit(PlayerManager playerManager, Jar_Grid grid, GameObject unitPrefab)
    {
        this.playerManager = playerManager;
        this.grid = grid;
        this.unitPrefab = unitPrefab;

        StringGenerator strGen = new StringGenerator(playerManager.playerNumber);
        spawnString = strGen.CalculateSpawnString(3);

        spawnChars = new List<Char>();
        foreach (char c in spawnString)
        {
            spawnChars.Add(c);
        }
    }
}