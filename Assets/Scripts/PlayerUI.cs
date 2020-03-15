using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    UnitManager unitManager;
    PlayerCommands playerCommands;
    TextMeshProUGUI queueInfo, queueStrings, playerState;
    TextMeshProUGUI[] selections = new TextMeshProUGUI[5];

    public GameObject playerCanvas;

    void Start()
    {
        unitManager = gameObject.GetComponent<UnitManager>();
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
<<<<<<< Updated upstream
        //Debug.Log("UpdatePlayerTextUI");
        playerInput.text = unitManager.typedLettersToString();
        if (playerInput.text == "")
        {
            UpdatePlayerTextUI("- - - - - - - -");
        }
    }

    public void UpdatePlayerTextUI(string text)
    {
        //Debug.Log("UpdatePlayerTextUI");
        playerInput.text = text;
=======
        
>>>>>>> Stashed changes
    }

    public void UpdateQueueUI()
    {
        
        queueInfo.text = unitManager.UnitQueueInfoToString();
        queueStrings.text = unitManager.UnitQueueToString();
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
<<<<<<< Updated upstream
        playerState.text = playerCommands.commandState.ToString() +" | " + unitManager.unitType[playerCommands.typeChoice -1].name + " - Lane: " + playerCommands.laneChoice;
        //Debug.Log("UpdateStateUI");
=======
        playerState.text = playerCommands.commandState.ToString() +" | " + unitSpawner.unitType[playerCommands.typeChoice -1].name + " - Lane: " + playerCommands.laneChoice;
        
>>>>>>> Stashed changes
        
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
<<<<<<< Updated upstream
                
                selectionOne.text = unitManager.unitType[1*playerCommands.unitTypePage -1].name;
                selectionTwo.text = unitManager.unitType[2*playerCommands.unitTypePage -1].name;
                selectionThree.text = unitManager.unitType[3*playerCommands.unitTypePage -1].name;
                selectionFour.text = "Next";
                selectionFive.text = "Return";
=======

                selections[0].text = unitSpawner.unitType[1*playerCommands.unitTypePage -1].name;
                selections[1].text = unitSpawner.unitType[2*playerCommands.unitTypePage -1].name;
                selections[2].text = unitSpawner.unitType[3*playerCommands.unitTypePage -1].name;
                selections[3].text = "Next";
                selections[4].text = "Return";
>>>>>>> Stashed changes
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
