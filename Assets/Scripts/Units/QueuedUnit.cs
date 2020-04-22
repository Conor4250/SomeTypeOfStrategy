using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueuedUnit
{
    public PlayerManager player;
    public int laneChoice, unitChoice;

    public string spawnString;
    public List<Char> spawnChars;

    public QueuedUnit(PlayerManager player, int laneChoice, int unitChoice)
    {
        this.player = player;
        this.laneChoice = laneChoice;
        this.unitChoice = unitChoice;

        StringGenerator strGen = new StringGenerator(player.playerNumber);
        spawnString = strGen.CalculateSpawnString(3);

        spawnChars = new List<Char>();
        foreach (char c in spawnString)
        {
            spawnChars.Add(c);
        }
    }
}