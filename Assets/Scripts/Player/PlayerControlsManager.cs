using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlsManager : MonoBehaviour
{
    private int unitChoicePageIndex;

    public PlayerManager playerManager;
    public ActionMapper actionMapper;
    public PlayerUnitManager unitManager;
    public PlayerCommands commands;

    private MasterInput controls;

    // Start is called before the first frame update
    public void Init(PlayerManager pm, ActionMapper am, PlayerUnitManager pum, PlayerCommands pc)
    {
        Debug.Log(pm.playerNumber + "  PlayerControlsManager Init Start");
        playerManager = pm;
        actionMapper = am;
        unitManager = pum;
        commands = pc;
        controls = new MasterInput();

        actionMapper.SubscribeToAnyKey(ProcessAnyKey);

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
        Debug.Log(pm.playerNumber + "  PlayerControlsManager Init Complete");
    }

    public void ProcessAnyKey(InputAction.CallbackContext callbackContext)
    {
        char c = char.Parse(callbackContext.control.name);
        unitManager.queueManager.ScanQueueForChar(c);
    }

    private void onAction(InputAction.CallbackContext ctx)
    {
        var buttonPressed = ctx.control.name;
        int commandInt = int.Parse(buttonPressed);

        if (playerManager.playerNumber == 2)
        {
            commandInt -= 5;
        }
        commands.ProcessCommand(commandInt);
    }

    private void OnDisable()
    {
        actionMapper.UnsubscribeToAnyKey(ProcessAnyKey);
    }
}