using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class ActionMapper : MonoBehaviour
{
    private string validInputs;
    private List<InputAction> inputActions;

    public void Init(string validInputs)
    {
        inputActions = new List<InputAction>();
        MapInputs(validInputs);
    }

    private void MapInputs(string validInputs)
    {
        validInputs = SanitizeString(validInputs);
        char[] c = validInputs.ToCharArray();

        for (int i = 0; i < c.Length; i++)
        {
            inputActions.Add(new InputAction(c[i] + "", binding: "<Keyboard>/" + c[i]));

            inputActions[i].Enable();

            //Debug.Log(inputActions[i]);
        }
    }

    private string SanitizeString(string s)
    {
        return string.Join("", s.ToCharArray().Distinct());
    }

    public void SubscribeToAnyKey(System.Action<InputAction.CallbackContext> func)
    {
        for (int i = 0; i < inputActions.Count; i++)
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