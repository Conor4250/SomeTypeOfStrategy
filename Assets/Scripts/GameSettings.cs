using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public string playerOneName, playerTwoName;
    public string playerOneKeys, playerTwoKeys;

    [ColorUsage(true, true)]
    public Color playerOneColor, playerTwoColor;

    [ColorUsage(true, true)]
    public Color[] colorOptions;

    public void SetPlayerOneName(string name)
    {
        playerOneName = name;
    }

    public void SetPlayerTwoName(string name)
    {
        playerTwoName = name;
    }

    public void SetPlayerOneColor(int colorIndex)
    {
        playerOneColor = colorOptions[colorIndex];
    }

    public void SetPlayerTwoColor(int colorIndex)
    {
        playerTwoColor = colorOptions[colorIndex];
    }
}