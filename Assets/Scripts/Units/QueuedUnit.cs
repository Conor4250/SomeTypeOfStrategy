using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public string spawnString;
    public List<Char> spawnChars;
    public Jar_Grid grid;
    public GameObject unitPrefab;
    public int laneIndex, playerNumber = 1;
    public PlayerManager playerManager;

    public QueuedUnit(PlayerManager playerManager, int laneIndex, Jar_Grid grid, GameObject unitPrefab)
    {
        this.playerManager = playerManager;
        this.laneIndex = laneIndex;
        this.grid = grid;
        this.unitPrefab = unitPrefab;

        StringGenerator strGen = new StringGenerator(playerNumber);
        spawnString = strGen.CalculateSpawnString(3);

        spawnChars = new List<Char>();
        foreach (char c in spawnString)
        {
            spawnChars.Add(c);
        }
    }
}