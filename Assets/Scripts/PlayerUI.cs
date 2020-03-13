using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    UnitManager unitManager;
    PlayerCommands playerCommands;
    public TextMeshProUGUI playerInput, queueInfo, queueStrings, playerState, selectionOne, selectionTwo, selectionThree, selectionFour, selectionFive;

    void Start()
    {
        unitManager = gameObject.GetComponent<UnitManager>();
        playerCommands = gameObject.GetComponent<PlayerCommands>();
        UpdateQueueUI();
        UpdatePlayerTextUI();
        UpdateSelectionUI();
        UpdateStateText();
    }

    public void UpdatePlayerTextUI()
    {
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
    }

    public void UpdateQueueUI()
    {
        
        queueInfo.text = unitManager.UnitQueueInfoToString();
        queueStrings.text = unitManager.UnitQueueToString();
        if (queueInfo.text == "" ||queueStrings.text == "" )
        {
            UpdateQueueUI("No Queued", "Units");
        }
        //Debug.Log("UpdateQueueUI");
    }

    public void UpdateQueueUI(string textInfo, string textString)
    {
        queueInfo.text = textInfo;
        queueStrings.text = textString;
        //Debug.Log("UpdateQueueUI");
    }

    public void UpdateStateText()
    {
        playerState.text = playerCommands.commandState.ToString() +" | " + unitManager.unitType[playerCommands.typeChoice -1].name + " - Lane: " + playerCommands.laneChoice;
        //Debug.Log("UpdateStateUI");
        
    }

    public void UpdateSelectionUI()
    {
        switch (playerCommands.commandState)
        {
            case PlayerCommands.CommandState.defaultState:
                selectionOne.text = "Spawn Unit";
                selectionTwo.text = "Set Lane";
                selectionThree.text = "Set Type";
                selectionFour.text = "Choose Upgrade";
                selectionFive.text = "Return";
                break;
            case PlayerCommands.CommandState.settingUnitLane:
                selectionOne.text = "Set Lane 1";
                selectionTwo.text = "Set Lane 2";
                selectionThree.text = "Set Lane 3";
                selectionFour.text = "Set Lane Auto";
                selectionFive.text = "Return";
                break;
            case PlayerCommands.CommandState.settingUnitType:
                
                selectionOne.text = unitManager.unitType[1*playerCommands.unitTypePage -1].name;
                selectionTwo.text = unitManager.unitType[2*playerCommands.unitTypePage -1].name;
                selectionThree.text = unitManager.unitType[3*playerCommands.unitTypePage -1].name;
                selectionFour.text = "Next";
                selectionFive.text = "Return";
                break;
            case PlayerCommands.CommandState.choosingAbility:
                selectionOne.text = "Set Lane 1";
                selectionTwo.text = "Set Lane 2";
                selectionThree.text = "Set Lane 3";
                selectionFour.text = "Set Lane Auto";
                selectionFive.text = "Return";
                break;
            case PlayerCommands.CommandState.choosingUpgrade:
                selectionOne.text = "Set Lane 1";
                selectionTwo.text = "Set Lane 2";
                selectionThree.text = "Set Lane 3";
                selectionFour.text = "Set Lane Auto";
                selectionFive.text = "Return";
                break;


            default:
                break;
        }
        UpdateStateText();
    }

}
