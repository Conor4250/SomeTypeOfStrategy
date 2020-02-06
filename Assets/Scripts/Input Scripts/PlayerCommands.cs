using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StandardUtilities.ScriptableValues;

public class PlayerCommands : MonoBehaviour
{
    public int playerNumber;
    MasterInput controls;
    public string playerInput;
    public ActionMapper mapper;
    public UserInterfaceManager UIM;
    PlayerUI playerUI;

    private void Awake()
    {
        playerInput = "";
        controls = new MasterInput();
        playerUI = gameObject.GetComponent<PlayerUI>();

    }

    private void Update()
    {
        
    }

    private void onActionOne(InputAction.CallbackContext ctx)
    {
        playerUI.processCommand(ctx.control.name);
    }
    private void onActionTwo(InputAction.CallbackContext ctx)
    {
        playerUI.processCommand(ctx.control.name);
    }
    private void onActionThree(InputAction.CallbackContext ctx)
    {
        playerUI.processCommand(ctx.control.name);
    }
    private void onActionFour(InputAction.CallbackContext ctx)
    {
        playerUI.processCommand(ctx.control.name);
    }
    private void onActionFive(InputAction.CallbackContext ctx)
    {
        playerUI.processCommand(ctx.control.name);
    }

    private void OnEnable()
    {
        mapper.SubscribeToAnyKey(ProcessAnyKey);
        controls.Enable();
        if (playerNumber == 1)
        {
            controls.InGame.Action1.performed += onActionOne;
            controls.InGame.Action2.performed += onActionTwo;
            controls.InGame.Action3.performed += onActionThree;
            controls.InGame.Action4.performed += onActionFour;
            controls.InGame.Action5.performed += onActionFive;
        }
        else
        {
            controls.InGame.Action6.performed += onActionOne;
            controls.InGame.Action7.performed += onActionTwo;
            controls.InGame.Action8.performed += onActionThree;
            controls.InGame.Action9.performed += onActionFour;
            controls.InGame.Action10.performed += onActionFive;
        }
    }

    private void OnDisable()
    {
        mapper.UnsubscribeToAnyKey(ProcessAnyKey);
    }

    public void ProcessAnyKey(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(callbackContext.control.name);
        playerInput += callbackContext.control.name;
        UIM.UpdateUserText(playerInput);
    }

    

   
}
