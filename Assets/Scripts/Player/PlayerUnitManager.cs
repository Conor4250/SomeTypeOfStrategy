using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitManager : MonoBehaviour
{
    public PlayerManager player;
    public List<QueuedUnit> waitingToSpawn;
    public List<UnitBrain> aliveUnits;
    public LaneContainer laneContainer;
    public GameObject[] availableUnits;
    public PlayerQueueManager queueManager;
    public Cell[] spawnCells;

    private Color playerColor;

    private bool initialised = false;

    public void Init(PlayerManager pm, PlayerQueueManager qm, Color color)
    {
        Debug.Log(pm.playerNumber + "  PlayerUnitManager Init Start");
        player = pm;
        queueManager = qm;
        playerColor = color;

        aliveUnits = new List<UnitBrain>();
        waitingToSpawn = new List<QueuedUnit>();

        laneContainer = player.laneContainer;
        availableUnits = player.gameManager.levelUnits;
        spawnCells = new Cell[laneContainer.laneCount];

        for (int i = 0; i < spawnCells.Length; i++)
        {
            if (player.playerNumber == 1)
            {
                spawnCells[i] = laneContainer.lanes[i].GetCell(0);
            }
            else
            {
                spawnCells[i] = laneContainer.lanes[i].GetCell(laneContainer.cellCount - 1);
            }
        }

        initialised = true;
        Debug.Log(pm.playerNumber + "  PlayerUnitManager Init Complete");
    }

    private void Update()
    {
        if (initialised)
        {
            SpawnWaitingUnit();
        }
    }

    public void AddUnitToSpawnList(QueuedUnit unit)
    {
        waitingToSpawn.Add(unit);
    }

    public void SpawnWaitingUnit()
    {
        if (waitingToSpawn.Count > 0)
        {
            var queuedUnit = waitingToSpawn[0];
            Debug.Log("Spawning Unit - Lane: " + queuedUnit.laneChoice + " Type: " + queuedUnit.unitChoice);
            if (!spawnCells[queuedUnit.laneChoice - 1].containsUnit)
            {
                waitingToSpawn.Remove(queuedUnit);
                var unit = Instantiate(availableUnits[queuedUnit.unitChoice - 1], spawnCells[queuedUnit.laneChoice - 1].GetWorldPosition(), Quaternion.identity);
                var brain = unit.GetComponent<UnitBrain>();
                aliveUnits.Add(brain);
                brain.initBrain(player, player.enemy, laneContainer.lanes[queuedUnit.laneChoice - 1], spawnCells[queuedUnit.laneChoice - 1], true, playerColor);
            }
        }
    }

    public void RemoveUnit(UnitBrain unit)
    {
        aliveUnits.Remove(unit);
    }
}