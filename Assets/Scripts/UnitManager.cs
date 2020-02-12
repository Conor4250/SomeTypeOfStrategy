using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //Spawn Points and Unit Types
    public Transform[] laneSpawns;
    public GameObject[] unitType;
    PlayerCommands playerCommands;
    PlayerUI playerUI;

    //Queued Units
    List<QueuedUnit> queuedUnits;
    List<QueuedUnit> activeUnits;
    List<char> typedLetters;
    bool typing, foundMatch;

    //Alive Units
    List<GameObject> livingUnits;

    void Start()
    {
        playerUI = gameObject.GetComponent<PlayerUI>();
        queuedUnits = new List<QueuedUnit>();
        activeUnits = new List<QueuedUnit>();
        livingUnits = new List<GameObject>();
        typedLetters = new List<char>();
        playerCommands = gameObject.GetComponent<PlayerCommands>();
        typing = false;
    }

    public void QueueUnit(int lane, int type, int level)
    {
        Debug.Log("Queueing Unit" + lane + type + level);
        QueuedUnit unit = new QueuedUnit(playerCommands.playerNumber, laneSpawns[lane], lane+1, unitType[type], level);
        queuedUnits.Add(unit);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
        Debug.Log(unit.spawnString);
    }

    public string UnitQueueToString()
    {
        string unitQueueString = "";
        if (typing)
        {
            for (int i = 0; i < activeUnits.Count; i++)
            {
                unitQueueString += activeUnits[i].spawnString + " \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueString += queuedUnits[i].spawnString + " \n";
            }
        }
        Debug.Log(unitQueueString);
        return unitQueueString;
    }

    public string UnitQueueInfoToString()
    {
        string unitQueueInfoString = "";
        if (typing)
        {
            for (int i = 0; i < activeUnits.Count; i++)
            {
                unitQueueInfoString += "T:"+ activeUnits[i].type.name + " P:" + activeUnits[i].laneInt + " L:" + (activeUnits[i].level + 1) +" \n";
            }
        }
        else
        {
            for (int i = 0; i < queuedUnits.Count; i++)
            {
                unitQueueInfoString += "T:" + queuedUnits[i].type.name + " P:" + queuedUnits[i].laneInt + " L:" + (queuedUnits[i].level + 1) + " \n";
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
                    activeUnits.Add(unit);
                    typing = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < activeUnits.Count; i++)
            {
                QueuedUnit unit = activeUnits[i];
                if (unit.spawnString == typedLettersToString())
                {
                    SpawnUnit(unit);
                    activeUnits.RemoveAt(i);
                    queuedUnits.Remove(unit);
                    continue;
                }
                else if (input != unit.spawnChars[typedLetters.Count - 1])
                {
                    
                    activeUnits.RemoveAt(i);
                    i--;
                }
            }
        }
        if (activeUnits.Count == 0)
        {
            typedLetters.Clear();
            typing = false;
        }
        Debug.Log("test     "+typedLettersToString());
    }

    public void SpawnUnit(QueuedUnit queuedUnit)
    {
        
        GameObject unit = Instantiate(queuedUnit.type, queuedUnit.lane.position, Quaternion.identity);
        livingUnits.Add(unit);
        var unitBrain = unit.GetComponent<UnitBrain>();
        unitBrain.setLevel(queuedUnit.level);
        unitBrain.setPlayer(queuedUnit.player);
        unitBrain.InitialiseStats();
    }

}
