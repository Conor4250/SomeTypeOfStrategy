using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    UnitSpawner unitSpawner;
    PlayerCommands playerCommands;
    TextMeshProUGUI queueInfo, queueStrings, playerState;
    TextMeshProUGUI[] selections = new TextMeshProUGUI[5];

    public GameObject playerCanvas;

    void Start()
    {
        unitSpawner = gameObject.GetComponent<UnitSpawner>();
        playerCommands = gameObject.GetComponent<PlayerCommands>();

        for (int i = 0; i < selections.Length; i++)
        {
            selections[i] = playerCanvas.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<TextMeshProUGUI>();
        }
        playerState = playerCanvas.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>();
        queueInfo = playerCanvas.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        queueStrings = playerCanvas.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();



        UpdateQueueUI();
        UpdatePlayerTextUI();
        UpdateSelectionUI();
        UpdateStateText();
    }

    public void UpdatePlayerTextUI()
    {
        
    }

    public void UpdateQueueUI()
    {
        
        queueInfo.text = unitSpawner.UnitQueueInfoToString();
        queueStrings.text = unitSpawner.UnitQueueToString();
        if (queueInfo.text == "" ||queueStrings.text == "" )
        {
            UpdateQueueUI("No Queued", "Units");
        }
    }

    public void UpdateQueueUI(string textInfo, string textString)
    {
        queueInfo.text = textInfo;
        queueStrings.text = textString;
    }

    public void UpdateStateText()
    {
        playerState.text = playerCommands.commandState.ToString() +" | " + unitSpawner.unitType[playerCommands.typeChoice -1].name + " - Lane: " + playerCommands.laneChoice;
        
        
    }

    public void UpdateSelectionUI()
    {
        switch (playerCommands.commandState)
        {
            case PlayerCommands.CommandState.defaultState:
                selections[0].text = "Spawn Unit";
                selections[1].text = "Set Lane";
                selections[2].text = "Set Type";
                selections[3].text = "Choose Upgrade";
                selections[4].text = "Return";
                break;
            case PlayerCommands.CommandState.settingUnitLane:
                selections[0].text = "Set Lane 1";
                selections[1].text = "Set Lane 2";
                selections[2].text = "Set Lane 3";
                selections[3].text = "Set Lane Auto";
                selections[4].text = "Return";
                break;
            case PlayerCommands.CommandState.settingUnitType:

                selections[0].text = unitSpawner.unitType[1*playerCommands.unitTypePage -1].name;
                selections[1].text = unitSpawner.unitType[2*playerCommands.unitTypePage -1].name;
                selections[2].text = unitSpawner.unitType[3*playerCommands.unitTypePage -1].name;
                selections[3].text = "Next";
                selections[4].text = "Return";
                break;
            case PlayerCommands.CommandState.choosingAbility:
                selections[0].text = "Set Lane 1";
                selections[1].text = "Set Lane 2";
                selections[2].text = "Set Lane 3";
                selections[3].text = "Set Lane Auto";
                selections[4].text = "Return";
                break;
            case PlayerCommands.CommandState.choosingUpgrade:
                selections[0].text = "Set Lane 1";
                selections[1].text = "Set Lane 2";
                selections[2].text = "Set Lane 3";
                selections[3].text = "Set Lane Auto";
                selections[4].text = "Return";
                break;


            default:
                break;
        }
        UpdateStateText();
    }

}
