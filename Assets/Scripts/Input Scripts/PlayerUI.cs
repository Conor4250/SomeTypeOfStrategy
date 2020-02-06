using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    UnitManager unitManager;
    public UIState uiState;
    int laneChoice;
    int typeChoice;
    int levelChoice;
    void Start()
    {
        uiState = UIState.startState;
        unitManager = gameObject.GetComponent<UnitManager>();
    }

    public void processCommand(string command)
    {
        if (uiState == UIState.startState)
        {
            processStartState(command);
        }
        else if (uiState == UIState.choosingUnitType)
        {
            processChoosingUnitType(command);
        }
        else if (uiState == UIState.choosingAbility)
        {
            processChoosingAbility(command);
        }
        else if (uiState == UIState.choosingUnitLevel)
        {
            processChoosingUnitLevel(command);
        }
        else if (uiState == UIState.choosingUpgrade)
        {
            processChoosingUpgrade(command);
        }

        Debug.Log(uiState);
    }

    private void processChoosingUpgrade(string command)
    {
    }

    private void processChoosingAbility(string command)
    {
    }

    private void processChoosingUnitType(string command)
    {
        if (command == "1")
        {
            typeChoice = 0;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == "2")
        {
            typeChoice = 1;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == "3")
        {
            typeChoice = 2;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == "4")
        {
            typeChoice = 2;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == "5")
        {
            typeChoice = 2;
            uiState = UIState.choosingUnitLevel;
        }
    }

    private void processChoosingUnitLevel(string command)
    {
        if (command == "1")
        {
            levelChoice = 0;
            uiState = UIState.startState;
        }
        else if (command == "2")
        {
            levelChoice = 1;
            Debug.Log("chose unit level 2");
            uiState = UIState.startState;
        }
        else if (command == "3")
        {
            levelChoice = 2;
            uiState = UIState.startState;
        }
        else if (command == "4")
        {
            levelChoice = 3;
            uiState = UIState.startState;
        }
        else if (command == "5")
        {
            levelChoice = 4;
            uiState = UIState.startState;
        }
        
        Debug.Log("Spawning Unit in Lane: " + laneChoice + "Type: " + typeChoice + " Level: " + levelChoice);
        

        
    }

    private void processStartState(string command)
    {
        if (command == "1")
        {
            laneChoice = 0;
            uiState = UIState.choosingUnitType;
        }
        else if (command == "2")
        {
            laneChoice = 1;
            uiState = UIState.choosingUnitType;
        }
        else if (command == "3")
        {
            laneChoice = 2;
            uiState = UIState.choosingUnitType;
        }
        else if (command == "4")
        {
            uiState = UIState.choosingAbility;
        }
        else if (command == "5")
        {
            uiState = UIState.choosingUpgrade;
        }
        Debug.Log(command);
    }

    public enum UIState
    {
        startState,
        choosingUnitType,
        choosingUnitLevel,
        choosingAbility,
        choosingUpgrade
    }
}
