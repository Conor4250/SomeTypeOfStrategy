using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StandardUtilities.ScriptableValues;

public class PlayerCommands : MonoBehaviour
{
    
    public StringVariable playerInput;
    public ActionMapper mapper;
    public UserInterfaceManager UIM;

    private void Awake()
    {
        playerInput.Value = "";
    }

    private void OnEnable()
    {
        mapper.SubscribeToAnyKey(ProcessAnyKey);

    }

    private void OnDisable()
    {
        mapper.UnsubscribeToAnyKey(ProcessAnyKey);
    }

    public void ProcessAnyKey(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(callbackContext.control.name);
        playerInput.Value += callbackContext.control.name;
        UIM.UpdateUserText(playerInput.Value);
    }

    public void RemoveLetter()
    {
        //playerInput.Value = playerInput.Value.Substring(0, Mathf.Max(0, playerInput.Value.Length - 1));
        playerInput.Value = "";
        UIM.UpdateUserText(playerInput.Value);
        Debug.Log("backspace");
    }

   
}
