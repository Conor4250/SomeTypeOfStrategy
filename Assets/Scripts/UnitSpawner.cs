using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public PlayerManager playerManager;

    //Spawn Points and Unit Types
    public GameObject[] unitTypes;

    public Jar_GridContainer lanes;
    public Jar_GridCell[] playerSpawnCells;

    public PlayerUI playerUI;

    //Managed Unit Lists
    public List<QueuedUnit> queuedUnits;

    private List<QueuedUnit> matchedUnits;
    private List<QueuedUnit> waitingToSpawn;

    //typing info
    private List<char> typedLetters;

    private bool typing = false;

    private void Start()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
        playerUI = gameObject.GetComponent<PlayerUI>();

        //initiialise lists
        queuedUnits = new List<QueuedUnit>();
        Debug.Log("queuedUnits = new List<QueuedUnit>();");
        matchedUnits = new List<QueuedUnit>();
        waitingToSpawn = new List<QueuedUnit>();
        typedLetters = new List<char>();
    }

    public void lateInit()
    {
        queuedUnits = new List<QueuedUnit>();
        Debug.Log("queuedUnits = new List<QueuedUnit>();");
        matchedUnits = new List<QueuedUnit>();
    }

    private void Update()
    {
        if (waitingToSpawn.Count > 0)
        {
            if (!waitingToSpawn[0].grid.GetCell(0, 0).ContainsUnit())
            {
                SpawnUnit(waitingToSpawn[0]);
                waitingToSpawn.RemoveAt(0);
            }
        }
    }

    public void QueueUnit(int laneIndex, int typeIndex)
    {
        Debug.Log("Queueing Unit: Lane - " + (laneIndex + 1) + ", Type - " + (typeIndex + 1));
        QueuedUnit unit = new QueuedUnit(playerManager, lanes.grids[laneIndex], unitTypes[typeIndex]);
        queuedUnits.Add(unit);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
    }

    public void PrepareUnit(QueuedUnit queuedUnit)
    {
        matchedUnits.Clear();
        typedLetters.Clear();
        typing = false;
        if (!playerSpawnCells[queuedUnit.grid.GridIndex].ContainsUnit())
        {
            SpawnUnit(queuedUnit);
        }
        else
        {
            waitingToSpawn.Add(queuedUnit);
        }

        queuedUnits.Remove(queuedUnit);
    }

    public void SpawnUnit(QueuedUnit queuedUnit)
    {
        GameObject spawnedUnit = Instantiate(queuedUnit.unitPrefab, playerSpawnCells[queuedUnit.grid.GridIndex].GetWorldPosition(), Quaternion.identity);
        var unitStateController = spawnedUnit.GetComponent<UnitStateController>();
        unitStateController.SetCurrentCell(playerSpawnCells[queuedUnit.grid.GridIndex]);
        spawnedUnit.SetActive(true);
        unitStateController.Init(queuedUnit);
    }

    public void ScanQueueForChar(char input)
    {
        typedLetters.Add(input);
        Debug.Log("started     " + typedLettersToString());
        if (!typing)
        {
            foreach (QueuedUnit unit in queuedUnits)
            {
                if (input == unit.spawnChars[0])
                {
                    matchedUnits.Add(unit);
                    typing = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < matchedUnits.Count; i++)
            {
                QueuedUnit unit = matchedUnits[i];
                if (unit.spawnString == typedLettersToString()) //if theres an exact match
                {
                    PrepareUnit(unit);
                    continue;
                }
                else if (input != unit.spawnChars[typedLetters.Count - 1]) //if input doesnt match anything
                {
                    matchedUnits.RemoveAt(i);
                    i--;
                }
            }
        }

        if (matchedUnits.Count == 0)
        {
            typedLetters.Clear();
            typing = false;
        }
        Debug.Log("test     " + typedLettersToString());
    }

    public string UnitQueueToString()
    {
        string unitQueueString = "";
        if (typing)
        {
            for (int i = 0; i < matchedUnits.Count; i++)
            {
                unitQueueString += matchedUnits[i].spawnString + " \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueString += queuedUnits[i].spawnString + " \n";
            }
        }
        //Debug.Log(unitQueueString);
        return unitQueueString;
    }

    public string UnitQueueInfoToString()
    {
        string unitQueueInfoString = "";
        if (typing)
        {
            for (int i = 0; i < matchedUnits.Count; i++)
            {
                unitQueueInfoString += "T:" + matchedUnits[i].unitPrefab.name + " L:" + (matchedUnits[i].grid.GridName) + " \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueInfoString += "T:" + queuedUnits[i].unitPrefab.name + " L:" + (queuedUnits[i].grid.GridName) + " \n";
            }
        }
        return unitQueueInfoString;
    }

    public string typedLettersToString()
    {
        string s = "";
        for (int i = 0; i < typedLetters.Count; i++)
        {
            s += typedLetters[i];
        }
        return s;
    }
}