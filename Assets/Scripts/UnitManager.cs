using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //Spawn Points and Unit Types
    public GameObject[] unitType;
    PlayerCommands playerCommands;
    PlayerUI playerUI;
    
    //Queued Units
    public List<QueuedUnit> queuedUnits;
    List<QueuedUnit> matchedUnits;

    List<QueuedUnit> waitingToSpawn;

    List<char> typedLetters;
    bool typing, foundMatch;

    //Alive Units
    public LaneContainer laneContainer;

    void Start()
    {
        playerUI = gameObject.GetComponent<PlayerUI>();
        playerCommands = gameObject.GetComponent<PlayerCommands>();
        queuedUnits = new List<QueuedUnit>();
        matchedUnits = new List<QueuedUnit>();
        waitingToSpawn = new List<QueuedUnit>();

        typedLetters = new List<char>();
        typing = false;
    }

    void Update()
    {
        if (waitingToSpawn.Count > 0)
        {
            if (!laneContainer.lanes[waitingToSpawn[0].laneIndex].GetInhabitant(0,0))
            {
                SpawnUnit(waitingToSpawn[0]);
                waitingToSpawn.RemoveAt(0);
            }
        }
    }

    public void QueueUnit(int laneIndex, int typeIndex)
    {
        Debug.Log("Queueing Unit: Lane - " + (laneIndex+1) + ", Type - " + (typeIndex+1));
        QueuedUnit unit = new QueuedUnit(playerCommands.playerNumber, laneIndex, unitType[typeIndex], laneContainer);
        queuedUnits.Add(unit);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
        
        //Debug.Log(unit.spawnString);
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
<<<<<<< Updated upstream:Assets/Scripts/UnitManager.cs
        string unitQueueInfoString = "";
        if (typing)
        {
            for (int i = 0; i < matchedUnits.Count; i++)
            {
                unitQueueInfoString += "T:"+ matchedUnits[i].unitPrefab.name + " L:" + (matchedUnits[i].laneIndex + 1) +" \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueInfoString += "T:" + queuedUnits[i].unitPrefab.name + " L:" + (queuedUnits[i].laneIndex +1) + " \n";
            }
        }
        return unitQueueInfoString;
=======
        GameObject spawnedUnit = Instantiate(queuedUnit.unitPrefab, queuedUnit.grid.spawnCells[playerNumber - 1].GetWorldPosition(), Quaternion.identity);
        UnitStateController unitStateController = spawnedUnit.GetComponent<UnitStateController>();
        spawnedUnit.SetActive(true);
        unitStateController.Init(queuedUnit);
>>>>>>> Stashed changes:Assets/Scripts/UnitSpawner.cs
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
        Debug.Log("test     "+typedLettersToString());
    }

    public void PrepareUnit(QueuedUnit queuedUnit)
    {
        matchedUnits.Clear();
        
        typedLetters.Clear();
        typing = false;

        if (playerCommands.playerNumber == 1)
        {
            if (laneContainer.lanes[queuedUnit.laneIndex].GetInhabitant(0,0) == null)
            {
                SpawnUnit(queuedUnit);
            }
            else
            {
                waitingToSpawn.Add(queuedUnit);
            }
        }
        else if (playerCommands.playerNumber == 2)
        {
            if (laneContainer.lanes[queuedUnit.laneIndex].GetInhabitant(0, laneContainer.laneWidth)==null)
            {
                SpawnUnit(queuedUnit);
            }
            else
            {
                waitingToSpawn.Add(queuedUnit);
            }
        }
        queuedUnits.Remove(queuedUnit);
    }

    public void SpawnUnit(QueuedUnit queuedUnit)
    {
        GameObject spawnedUnit = Instantiate(queuedUnit.unitPrefab, new Vector3(0,0,0), Quaternion.identity);
        UnitStateController unitStateController = spawnedUnit.GetComponent<UnitStateController>();
        laneContainer.lanes[queuedUnit.laneIndex].SetInhabitant(0,0, spawnedUnit);
        spawnedUnit.SetActive(true);
        unitStateController.Init(queuedUnit);
    }

}
