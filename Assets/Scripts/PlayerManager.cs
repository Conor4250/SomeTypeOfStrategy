using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;

    private ManagerSingleton gameManager;
    private int playerHealth;
    private string playerName;

    public Jar_GridContainer lanes;
    public Jar_GridCell[] playerSpawnCells;

    public void initialisePlayer(ManagerSingleton gameManager, int playerNumber, string playerName, int startingHealth, Jar_GridContainer lanes, string playerKeys, GameObject[] unitTypes)
    {
        this.gameManager = gameManager;
        this.playerNumber = playerNumber;
        this.playerName = playerName;
        playerHealth = startingHealth;
        this.lanes = lanes;

        var commands = gameObject.AddComponent<PlayerCommands>();
        var mapper = gameObject.AddComponent<ActionMapper>();
        var spawner = gameObject.AddComponent<UnitSpawner>();
        var ui = gameObject.AddComponent<PlayerUI>();

        commands.playerManager = this;
        commands.mapper = mapper;

        mapper.validInputs = playerKeys;

        spawner.playerManager = this;
        spawner.unitTypes = unitTypes;
        spawner.lanes = lanes;
        spawner.playerSpawnCells = playerSpawnCells;
        spawner.playerUI = ui;

        //assign spawn cells
        if (playerNumber == 1)
        {
            playerSpawnCells = new Jar_GridCell[lanes.laneCount];
            for (int i = 0; i < playerSpawnCells.Length; i++)
            {
                playerSpawnCells[i] = lanes.grids[i].gridCellArray[0, 0];
            }
        }
        else
        {
            playerSpawnCells = new Jar_GridCell[lanes.laneCount];
            for (int i = 0; i < playerSpawnCells.Length; i++)
            {
                playerSpawnCells[i] = lanes.grids[i].gridCellArray[lanes.gridWidth - 1, 0];
            }
        }
    }

    public void damagePlayer(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            gameManager.EndGame(playerNumber);
        }
    }
}