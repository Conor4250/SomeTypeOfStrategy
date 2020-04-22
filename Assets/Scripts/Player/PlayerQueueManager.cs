using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQueueManager : MonoBehaviour
{
    private PlayerManager player;
    private PlayerUnitManager unitManager;
    public PlayerCanvasManager canvasManager;

    public List<QueuedUnit> queuedUnits;

    public List<QueuedUnit> matchedUnits;

    public List<char> typedLetters;
    public bool matchingUnits = false;

    public void Init(PlayerManager pm, PlayerUnitManager pum, PlayerCanvasManager pcm)
    {
        Debug.Log(pm.playerNumber + "  PlayerQueueManager Init Start");
        player = pm;
        unitManager = pum;
        canvasManager = pcm;

        queuedUnits = new List<QueuedUnit>();
        matchedUnits = new List<QueuedUnit>();
        typedLetters = new List<char>();
        Debug.Log(pm.playerNumber + "  PlayerQueueManager Init Complete");
    }

    public void QueueUnit(int laneChoice, int unitChoice)
    {
        Debug.Log("Queueing Unit: Lane - " + (laneChoice) + ", Type - " + (unitChoice));
        QueuedUnit unit = new QueuedUnit(unitManager.player, laneChoice, unitChoice);
        queuedUnits.Add(unit);
        canvasManager.UpdateCanvases();
        Debug.Log("QueuedUnits: " + queuedUnits.Count);
    }

    public void ScanQueueForChar(char input)
    {
        typedLetters.Add(input);
        Debug.Log(new string(typedLetters.ToArray()));
        //if not already comparing, reset match list and start comparing
        if (!matchingUnits)
        {
            matchingUnits = true;
            matchedUnits = queuedUnits;
        }

        if (queuedUnits.Count > 0)
        {
            List<QueuedUnit> tempMatchedUnits = new List<QueuedUnit>();
            //for each matchedUnit
            for (int i = 0; i < matchedUnits.Count; i++)
            {
                QueuedUnit unit = matchedUnits[i];
                string unitCompareString = unit.spawnString.Substring(0, typedLetters.Count);
                string playerCompareString = new string(typedLetters.ToArray()).Substring(0, typedLetters.Count);
                //if perfect match, spawn the unit
                if (unit.spawnString == playerCompareString)
                {
                    unitManager.AddUnitToSpawnList(unit);
                    queuedUnits.Remove(unit);
                    typedLetters.Clear();
                    matchingUnits = false;
                    break;
                } //else delete the units that do not match from the matching list
                else if (unitCompareString == playerCompareString)
                {
                    tempMatchedUnits.Add(unit);
                }
            }

            //if no more matching units exist, set matching to false
            if (tempMatchedUnits.Count == 0)
            {
                matchingUnits = false;
                typedLetters.Clear();
            }
            else
            {
                matchedUnits = tempMatchedUnits;
            }
        }

        canvasManager.UpdateCanvases();
    }

    //public void ScanQueueForChar(char input)
    //{
    //    typedLetters.Add(input);
    //    Debug.Log("Typed: " + typedLettersToString());

    //    if (!typing)
    //    {
    //        matchedUnits = queuedUnits;
    //        typing = true;
    //    }

    //    for (int i = 0; i < matchedUnits.Count; i++)
    //    {
    //        QueuedUnit unit = matchedUnits[i];
    //        if (unit.spawnString == typedLettersToString()) //if theres an exact match
    //        {
    //            unitManager.AddUnitToSpawnList(unit);
    //            queuedUnits.Remove(unit);
    //            typedLetters.Clear();
    //            typing = false;
    //            matchedUnits = queuedUnits;
    //        }
    //        else if (unit.spawnString.Substring(0, typedLetters.Count) != typedLettersToString()) //if input doesnt match anything
    //        {
    //            matchedUnits.Remove(unit);
    //        }
    //    }

    //    if (matchedUnits.Count == 0)
    //    {
    //        typedLetters.Clear();
    //        typing = false;
    //        matchedUnits = queuedUnits;
    //    }

    //    canvasManager.UpdateCanvases();
    //}

    //public string typedLettersToString()
    //{
    //    string s = "";
    //    for (int i = 0; i < typedLetters.Count; i++)
    //    {
    //        s += typedLetters[i];
    //    }
    //    return s;
    //}
}