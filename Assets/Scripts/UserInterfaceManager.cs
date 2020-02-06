using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterfaceManager : MonoBehaviour
{
    public TMP_Text userText;

    public void UpdateUserText(string text)
    {
        userText.text = text;
    }

}
