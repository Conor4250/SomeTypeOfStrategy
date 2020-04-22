using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI Text Storage")]
public class UIStorage : ScriptableObject
{
    public string[] rootSelectionText;
    public string[] laneSelectionText;
    public string[] unitSelectionText;
    public string[] ablilitiesSelectionText;
    public string[] upgradesSelectionText;
}