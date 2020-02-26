using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StandardUtilities.ScriptableValues;

public class PlayerCommands : MonoBehaviour
{
    public int playerNumber;
    public MasterInput controls;
    public ActionMapper mapper;
    UnitManager UM;
    PlayerUI playerUI;

    private void Awake()
    {
        
        controls = new MasterInput();
        UM = gameObject.GetComponent<UnitManager>();
        playerUI = gameObject.GetComponent<PlayerUI>();

    }

    private void Update()
    {
        
    }

    private void onAction(InputAction.CallbackContext ctx)
    {
        var buttonPressed = ctx.control.name;
        int commandInt = int.Parse(buttonPressed);
        
        if (playerNumber == 2)
        {
            commandInt -= 5;
        }

        playerUI.ProcessCommand(commandInt);
    }

    private void OnEnable()
    {
        mapper.SubscribeToAnyKey(ProcessAnyKey);
        controls.Enable();
        if (playerNumber == 1)
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
            controls.InGame.Action10.performed += onAction;
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
        UM.ScanQueueForChar(c);
        playerUI.UpdatePlayerTextUI();
        playerUI.UpdateQueueUI();
    }

    

   
}
