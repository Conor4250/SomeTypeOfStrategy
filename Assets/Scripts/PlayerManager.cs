using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;

    private ManagerSingleton gameManager;
    public PlayerManager enemyManager;
    private int playerHealth;
    private string playerName;

    public GameObject playerUICanvas;

    public Jar_GridContainer lanes;
    public Jar_GridCell[] playerSpawnCells;

    public void initialisePlayer(ManagerSingleton gameManager, int playerNumber, string playerName, int startingHealth, Jar_GridContainer lanes, string playerKeys, GameObject[] unitTypes, GameObject playerUICanvas, Jar_GridCell[] playerSpawnCells)
    {
        this.gameManager = gameManager;
        this.playerNumber = playerNumber;
        this.playerName = playerName;
        playerHealth = startingHealth;
        this.lanes = lanes;
        this.playerUICanvas = playerUICanvas;
        this.playerSpawnCells = playerSpawnCells;

        var mapper = gameObject.AddComponent<ActionMapper>();
        mapper.validInputs = playerKeys;
        mapper.initialiseInputs();

        var commands = gameObject.AddComponent<PlayerCommands>();

        var spawner = gameObject.AddComponent<UnitSpawner>();
        spawner.unitTypes = unitTypes;
        spawner.lanes = lanes;
        spawner.lateInit();

        var ui = gameObject.AddComponent<PlayerUI>();
        ui.InitialiseUI(playerUICanvas);

        commands.lateInit();
        spawner.playerSpawnCells = playerSpawnCells;
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