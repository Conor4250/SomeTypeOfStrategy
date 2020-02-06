using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //Spawn Points and Unit Types
    public Transform[] laneSpawns;
    public GameObject[,] unitTypes;

    //Queued Units
    List<QueuedUnit> queuedUnits;
    List<QueuedUnit> activeUnits;
    List<char> typedLetters;
    bool typing;

    //Alive Units
    List<GameObject> livingUnits;

    void Start()
    {
        queuedUnits = new List<QueuedUnit>();
        livingUnits = new List<GameObject>();
        typing = false;
    }

    public void QueueUnit(int lane, int type, int level)
    {
        QueuedUnit unit = new QueuedUnit(laneSpawns[lane], unitTypes[type,level], level);
        queuedUnits.Add(unit);
    }

    public void ScanQueueForChar(char input)
    {
        if (typing == false)
        {
            foreach (QueuedUnit unit in queuedUnits)
            {
                if (input == unit.spawnChars[0])
                {
                    activeUnits.Add(unit);
                    typedLetters.Add(input);
                    typing = true;
                }
            }
        }
        else
        {

            for (int i = 0; i < activeUnits.Count; i++)
            {
                QueuedUnit unit = activeUnits[i];
                if (unit.spawnChars == typedLetters)
                {
                    livingUnits.Add(unit.SpawnUnit());
                }
                else if (input != unit.spawnChars[typedLetters.Count])
                {
                    activeUnits.RemoveAt(i);
                    i--;
                    typing = false;
                }
                else
                {
                    typedLetters.Add(input);
                }
            }
            
        }
    }
    
    private void spawnUnit()
    {
        
    }


}
