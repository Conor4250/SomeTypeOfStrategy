using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerNumber;
    public Color playerColor;

    public GameManager gameManager;
    public PlayerManager enemy;
    public string playerName;

    public GameObject mainUI;
    public GameObject playerUI;
    public PlayerHome playerHome;

    public LaneContainer laneContainer;
    public ActionMapper actionMapper;
    public PlayerUnitManager unitManager;
    public PlayerQueueManager queueManager;
    public PlayerCommands commands;
    public PlayerControlsManager controlsManager;
    public PlayerCanvasManager canvasManager;

    public void Init(GameManager gameManager, int playerNumber, string playerName, int playerStartingHealth, LaneContainer laneContainer, string playerKeys, GameObject[] unitTypes, GameObject mainUI, GameObject startUI, GameObject playerHome, Color color)
    {
        Debug.Log(playerNumber + "  PlayerManager Init Start");
        this.gameManager = gameManager;
        this.playerNumber = playerNumber;
        this.playerName = playerName;
        playerColor = color;
        this.laneContainer = laneContainer;
        this.mainUI = mainUI;
        this.playerHome = playerHome.GetComponent<PlayerHome>();
        this.playerHome.Init(gameManager, this, playerStartingHealth, playerColor);
        playerUI = startUI;

        canvasManager = playerUI.GetComponent<PlayerCanvasManager>();
        actionMapper = gameObject.AddComponent<ActionMapper>();
        unitManager = gameObject.AddComponent<PlayerUnitManager>();
        queueManager = gameObject.AddComponent<PlayerQueueManager>();
        commands = gameObject.AddComponent<PlayerCommands>();
        controlsManager = gameObject.AddComponent<PlayerControlsManager>();

        canvasManager.Init(this, queueManager, commands);
        actionMapper.Init(playerKeys);
        unitManager.Init(this, queueManager, playerColor);
        queueManager.Init(this, unitManager, canvasManager);
        commands.Init(this, unitManager, canvasManager);
        controlsManager.Init(this, actionMapper, unitManager, commands);

        canvasManager.UpdateCanvases();

        //StartCoroutine(InitialUnitSpawn());
        Debug.Log(playerNumber + "  PlayerControlsManager Init Complete");
    }

    public IEnumerator InitialUnitSpawn()
    {
        for (int l = 0; l < laneContainer.laneCount; l++)
        {
            yield return new WaitForSeconds(0.2f);
            unitManager.AddUnitToSpawnList(new QueuedUnit(this, l + 1, 1));
        }
    }
}