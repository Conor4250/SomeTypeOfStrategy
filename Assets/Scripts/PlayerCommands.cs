using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StandardUtilities.ScriptableValues;

public class PlayerCommands : MonoBehaviour
{
    public int laneChoice, typeChoice;
    public PlayerManager playerManager;

    private MasterInput controls;
    public ActionMapper mapper;

    private UnitSpawner unitManager;

    private PlayerUI playerUI;
    public int unitTypePage;
    public CommandState commandState;

    private bool queueBlock = false;
    private bool randomLane = false;

    private void Awake()
    {
        playerManager = gameObject.GetComponent<PlayerManager>();
        controls = new MasterInput();
        mapper = gameObject.GetComponent<ActionMapper>();
        unitTypePage = 1;
        laneChoice = 1;
        typeChoice = 1;
    }

    public void lateInit()
    {
        unitManager = gameObject.GetComponent<UnitSpawner>();
        playerUI = gameObject.GetComponent<PlayerUI>();
    }

    private void onAction(InputAction.CallbackContext ctx)
    {
        var buttonPressed = ctx.control.name;
        int commandInt = int.Parse(buttonPressed);

        if (playerManager.playerNumber == 2)
        {
            commandInt -= 5;
        }

        ProcessCommand(commandInt);
    }

    private void OnEnable()
    {
        mapper.SubscribeToAnyKey(ProcessAnyKey);
        controls.Enable();
        if (playerManager.playerNumber == 1)
        {
            controls.InGame.Action1.performed += onAction;
            controls.InGame.Action2.performed += onAction;
            controls.InGame.Action3.performed += onAction;
            controls.InGame.Action4.performed += onAction;
            controls.InGame.Action5.performed += onAction;
        }
        else
        {
            controls.InGame.Action6.performed += onAction;
            controls.InGame.Action7.performed += onAction;
            controls.InGame.Action8.performed += onAction;
            controls.InGame.Action9.performed += onAction;
            controls.InGame.Action0.performed += onAction;
        }
    }

    private void OnDisable()
    {
        mapper.UnsubscribeToAnyKey(ProcessAnyKey);
    }

    public void ProcessAnyKey(InputAction.CallbackContext callbackContext)
    {
        char c = char.Parse(callbackContext.control.name);
        Debug.Log(c);
        unitManager.ScanQueueForChar(c);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
    }

    public void ProcessCommand(int command)
    {
        switch (commandState)
        {
            case CommandState.defaultState:
                ProcessDefaultState(command);
                Debug.Log("ProcessDefaultState(command);");
                break;

            case CommandState.settingUnitLane:
                SetUnitLane(command);
                Debug.Log("SetUnitLane(command);");
                break;

            case CommandState.settingUnitType:
                SetUnitType(command);
                Debug.Log("SetUnitType(command);");
                break;

            case CommandState.choosingAbility:
                ChooseAbility(command);
                Debug.Log("ChooseAbility(command);");
                break;

            case CommandState.choosingUpgrade:
                ChooseUpgrade(command);
                Debug.Log("ChooseUpgrade(command);");
                break;

            default:
                break;
        }
    }

    private void ProcessDefaultState(int command)
    {
        switch (command)
        {
            case 1:
                if (!queueBlock)
                {
                    if (randomLane)
                    {
                        laneChoice = (int)Random.Range(1, 4);
                    }
                    unitManager.QueueUnit(laneChoice - 1, typeChoice - 1);
                    queueBlock = true;
                    StartCoroutine(queuePause());
                }
                break;

            case 2:
                SetCommandState(CommandState.settingUnitLane);
                break;

            case 3:
                SetCommandState(CommandState.settingUnitType);
                break;

            case 4:
                SetCommandState(CommandState.choosingAbility);
                break;

            case 5:
                unitManager.PrepareUnit(unitManager.queuedUnits[0]);
                break;

            default:
                break;
        }
    }

    private void SetUnitLane(int command)
    {
        switch (command)
        {
            case 1:
                laneChoice = 1;
                ResetState();
                break;

            case 2:
                laneChoice = 2;
                ResetState();
                break;

            case 3:
                laneChoice = 3;
                randomLane = false;
                ResetState();
                break;

            case 4:
                randomLane = true;
                ResetState();
                break;

            case 5:
                ResetState();
                break;

            default:
                break;
        }
    }

    private void SetUnitType(int command)
    {
        switch (command)
        {
            case 1:
                typeChoice = 1 * unitTypePage;
                ResetState();
                break;

            case 2:
                typeChoice = 2 * unitTypePage;
                ResetState();
                break;

            case 3:
                typeChoice = 3 * unitTypePage;
                ResetState();
                break;

            case 4:
                unitTypePage++;
                break;

            case 5:
                unitTypePage = 1;
                ResetState();
                break;

            default:
                break;
        }
    }

    private void ChooseAbility(int command)
    {
        switch (command)
        {
            case 1:
                ResetState();
                break;

            case 2:
                ResetState();
                break;

            case 3:
                ResetState();
                break;

            case 4:
                ResetState();
                break;

            case 5:
                ResetState();
                break;

            default:
                break;
        }
    }

    private void ChooseUpgrade(int command)
    {
        switch (command)
        {
            case 1:
                ResetState();
                break;

            case 2:
                ResetState();
                break;

            case 3:
                ResetState();
                break;

            case 4:
                ResetState();
                break;

            case 5:

                ResetState();
                break;

            default:
                break;
        }
    }

    public void SetCommandState(CommandState commandState)
    {
        this.commandState = commandState;
        playerUI.UpdateStateText();
        playerUI.UpdateSelectionUI();
    }

    private void ResetState()
    {
        commandState = CommandState.defaultState;
        playerUI.UpdateStateText();
        playerUI.UpdateSelectionUI();
    }

    private IEnumerator queuePause()
    {
        yield return new WaitForSeconds(2);
        queueBlock = false;
    }

    public enum CommandState
    {
        defaultState,
        settingUnitLane,
        settingUnitType,
        settingUnitLevel,
        choosingAbility,
        choosingUpgrade
    }
}