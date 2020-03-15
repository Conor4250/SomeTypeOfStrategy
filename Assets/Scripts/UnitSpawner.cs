using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    //Spawn Points and Unit Types
    public GameObject[] unitType;
    PlayerCommands playerCommands;
    PlayerUI playerUI;

    int playerNumber = 1;

    //Queued Units
    public List<QueuedUnit> queuedUnits;
    List<QueuedUnit> matchedUnits;

    List<QueuedUnit> waitingToSpawn;

    List<char> typedLetters;
    bool typing, foundMatch;

    //Alive Units
    public Jar_GridContainer gridContainer;

    void Start()
    {
        playerUI = gameObject.GetComponent<PlayerUI>();
        playerCommands = gameObject.GetComponent<PlayerCommands>();
        queuedUnits = new List<QueuedUnit>();
        matchedUnits = new List<QueuedUnit>();
        waitingToSpawn = new List<QueuedUnit>();

        playerNumber = playerCommands.playerNumber;

        typedLetters = new List<char>();
        typing = false;
    }

    void Update()
    {
        if (waitingToSpawn.Count > 0)
        {
            if (waitingToSpawn[0].grid.GetCellObjects(0,0).Count <=0)
            {
                SpawnUnit(waitingToSpawn[0]);
                waitingToSpawn.RemoveAt(0);
            }
        }
    }

    public void QueueUnit(int laneIndex, int typeIndex)
    {
        Debug.Log("Queueing Unit: Lane - " + (laneIndex+1) + ", Type - " + (typeIndex+1));
        QueuedUnit unit = new QueuedUnit(playerNumber, gridContainer.grids[laneIndex], unitType[typeIndex]);
        queuedUnits.Add(unit);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
    }

    public void PrepareUnit(QueuedUnit queuedUnit)
    {
        matchedUnits.Clear();
        typedLetters.Clear();
        typing = false;
        if (queuedUnit.grid.spawnCells[playerNumber - 1] == null)
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
        GameObject spawnedUnit = Instantiate(queuedUnit.unitPrefab, queuedUnit.grid.spawnCells[playerNumber - 1].GetWorldPosition(), Quaternion.identity);
        UnitStateController unitStateController = spawnedUnit.GetComponent<UnitStateController>();
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
                unitQueueInfoString += "T:" + matchedUnits[i].unitPrefab.name + " L:" + (matchedUnits[i].grid.gridName) + " \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueInfoString += "T:" + queuedUnits[i].unitPrefab.name + " L:" + (queuedUnits[i].grid.gridName) + " \n";
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
