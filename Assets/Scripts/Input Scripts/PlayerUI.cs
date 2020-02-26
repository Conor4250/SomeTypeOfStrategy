using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    UnitManager unitManager;
    public UIState uiState;
    int laneChoice;
    int typeChoice;
    int levelChoice;
    public TextMeshProUGUI playerInput;
    public TextMeshProUGUI queueInfo;
    public TextMeshProUGUI queueStrings;
    public Canvas playerInputCanvas, playerSelectionUI, queueInfoCanvas, queueStringsCanvas;

    void Start()
    {
        uiState = UIState.startState;
        unitManager = gameObject.GetComponent<UnitManager>();
    }

    public void UpdatePlayerTextUI()
    {
        Debug.Log("UpdatePlayerTextUI");
        playerInput.text = unitManager.typedLettersToString();
    }
    public void UpdateQueueUI()
    {
        Debug.Log("UpdateQueueUI");
        queueInfo.text = unitManager.UnitQueueInfoToString();
        queueStrings.text = unitManager.UnitQueueToString();
    }

    public void UpdateSelectionUI()
    {
        Debug.Log("UpdateSelectionUI");
    }


    public void ProcessCommand(int command)
    {
        if (uiState == UIState.startState)
        {
            ProcessStartState(command);
        }
        else if (uiState == UIState.choosingUnitType)
        {
            ProcessChoosingUnitType(command);
        }
        else if (uiState == UIState.choosingAbility)
        {
            ProcessChoosingAbility(command);
        }
        else if (uiState == UIState.choosingUnitLevel)
        {
            ProcessChoosingUnitLevel(command);
        }
        else if (uiState == UIState.choosingUpgrade)
        {
            ProcessChoosingUpgrade(command);
        }

        Debug.Log(uiState);
    }

    private void ProcessChoosingUpgrade(int command)
    {
    }

    private void ProcessChoosingAbility(int command)
    {
    }

    private void ProcessChoosingUnitType(int command)
    {
        Debug.Log("processChoosingUnitType");
        if (command == 1)
        {
            typeChoice = 0;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == 2)
        {
            typeChoice = 1;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == 3)
        {
            typeChoice = 2;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == 4)
        {
            typeChoice = 3;
            uiState = UIState.choosingUnitLevel;
        }
        else if (command == 5)
        {
            typeChoice = 4;
            uiState = UIState.choosingUnitLevel;
        }
    }

    private void ProcessChoosingUnitLevel(int command)
    {
        Debug.Log("processChoosingUnitLevel");

        if (command == 1)
        {
            levelChoice = 0;
            uiState = UIState.startState;
        }
        else if (command == 2)
        {
            levelChoice = 1;
            uiState = UIState.startState;
        }
        else if (command ==3)
        {
            levelChoice = 2;
            uiState = UIState.startState;
        }
        else if (command == 4)
        {
            levelChoice = 3;
            uiState = UIState.startState;
        }
        else if (command == 5)
        {
            levelChoice = 4;
            uiState = UIState.startState;
        }

        unitManager.QueueUnit(laneChoice,typeChoice,levelChoice);

        Debug.Log("Queueing Unit in Lane: " + laneChoice + "Type: " + typeChoice + " Level: " + levelChoice);
        

        
    }

    private void ProcessStartState(int command)
    {
        if (command == 1)
        {
            laneChoice = 0;
            uiState = UIState.choosingUnitType;
        }
        else if (command == 2)
        {
            laneChoice = 1;
            uiState = UIState.choosingUnitType;
        }
        else if (command == 3)
        {
            laneChoice = 2;
            uiState = UIState.choosingUnitType;
        }
        else if (command == 4)
        {
            uiState = UIState.choosingAbility;
        }
        else if (command == 5)
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
