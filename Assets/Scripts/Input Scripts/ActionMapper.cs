using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class ActionMapper : MonoBehaviour
{
    public string validInputs;
    private List<InputAction> inputActions;


    private void Awake()
    {
        inputActions = new List<InputAction>();
        MapInputs(validInputs);
    }

    private string SanitizeString(string s)
    {
        return string.Join("", s.ToCharArray().Distinct());
    }

    private void MapInputs(string s)
    {
        s = SanitizeString(s);
        char[] c = s.ToCharArray();

        for(int i = 0; i < c.Length; i++)
        {
            inputActions.Add(new InputAction(c[i] + "", binding: "<Keyboard>/" + c[i]));

            inputActions[i].Enable();

            //Debug.Log(inputActions[i]);
        }
    }
    
    public void SubscribeToAnyKey(System.Action<InputAction.CallbackContext> func)
    {
        for(int i = 0; i < inputActions.Count; i++)
        {
            inputActions[i].performed += func;
        }
    }
    public void UnsubscribeToAnyKey(System.Action<InputAction.CallbackContext> func)
    {
        for (int i = 0; i < inputActions.Count; i++)
        {
            inputActions[i].performed -= func;
        }
    }
}
