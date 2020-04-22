using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "UI Text Storage")]
public class UIStorage : ScriptableObject
{
    public string[] rootSelectionText;
    public string[] laneSelectionText;
    public string[] unitSelectionText;

    public Sprite[] rootSelectionImages;
    public Sprite[] laneSelectionImages;
    public Sprite[] unitSelectionImages;
}