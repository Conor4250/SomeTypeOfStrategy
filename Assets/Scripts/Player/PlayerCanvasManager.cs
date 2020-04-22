using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCanvasManager : MonoBehaviour
{
    public GameObject unitStringCanvas, unitInfoCanvas, commandCanvas;

    //public GameObject[] unitStrings;
    public Image[] commandImages;

    public TextMeshProUGUI[] unitStrings, unitInfoText, commandText;
    public PlayerManager player;
    public PlayerQueueManager queueManager;
    public PlayerCommands commands;
    public UIStorage uiStorage;
    private bool initialised = false;

    public void Init(PlayerManager pm, PlayerQueueManager pqm, PlayerCommands pc)
    {
        Debug.Log(pm.playerNumber + "  CanvasManager Init Start");
        player = pm;
        queueManager = pqm;
        commands = pc;

        initialised = true;
        Debug.Log(pm.playerNumber + "  CanvasManager Init Complete");
    }

    public void UpdateCanvases()
    {
        if (initialised)
        {
            UpdateCommands();
            UpdateQueue();
        }
    }

    private void UpdateCommands()
    {
        switch (commands.interfaceState)
        {
            case PlayerCommands.InterfaceState.root:
                commandText[0].text = uiStorage.rootSelectionText[0];
                commandText[1].text = uiStorage.rootSelectionText[1];
                commandText[2].text = uiStorage.rootSelectionText[2];
                commandText[3].text = uiStorage.rootSelectionText[3];
                commandText[4].text = uiStorage.rootSelectionText[4];
                break;

            case PlayerCommands.InterfaceState.setLane:
                commandText[0].text = uiStorage.laneSelectionText[0];
                commandText[1].text = uiStorage.laneSelectionText[1];
                commandText[2].text = uiStorage.laneSelectionText[2];
                commandText[3].text = uiStorage.laneSelectionText[3];
                commandText[4].text = uiStorage.laneSelectionText[4];
                //Debug.Log("SetUnitLane(command);");
                break;

            case PlayerCommands.InterfaceState.setUnit:
                commandText[0].text = uiStorage.unitSelectionText[0];
                commandText[1].text = uiStorage.unitSelectionText[1];
                commandText[2].text = uiStorage.unitSelectionText[2];
                commandText[3].text = uiStorage.unitSelectionText[3];
                commandText[4].text = uiStorage.unitSelectionText[4];
                //Debug.Log("SetUnitType(command);");
                break;

            case PlayerCommands.InterfaceState.abilities:
                commandText[0].text = uiStorage.ablilitiesSelectionText[0];
                commandText[1].text = uiStorage.ablilitiesSelectionText[1];
                commandText[2].text = uiStorage.ablilitiesSelectionText[2];
                commandText[3].text = uiStorage.ablilitiesSelectionText[3];
                commandText[4].text = uiStorage.ablilitiesSelectionText[4];
                //Debug.Log("ChooseAbility(command);");
                break;

            case PlayerCommands.InterfaceState.upgrades:
                commandText[0].text = uiStorage.upgradesSelectionText[0];
                commandText[1].text = uiStorage.upgradesSelectionText[1];
                commandText[2].text = uiStorage.upgradesSelectionText[2];
                commandText[3].text = uiStorage.upgradesSelectionText[3];
                commandText[4].text = uiStorage.upgradesSelectionText[4];
                //Debug.Log("ChooseUpgrade(command);");
                break;

            default:
                break;
        }
    }

    private void UpdateQueue()
    {
        //List<List<char>> matchedUnitChars = new List<List<char>>();
        //List<string> matchedUnitInfo = new List<string>();

        int slotsToPopulate = CalculateSlotsToPopulate();
        Debug.Log(slotsToPopulate + "slotstopopulate");

        for (int i = 0; i < queueManager.matchedUnits.Count; i++)
        {
            if (queueManager.matchingUnits)
            {
                Debug.Log(queueManager.queuedUnits[i].spawnString);
            }
        }
        //populate queues
        PopulateUnitStrings(slotsToPopulate);
        PopulateUnitInfo(slotsToPopulate);
        ClearUnusedSlots(slotsToPopulate);
        Debug.Log("QUEUEUPDATED");
    }

    //private void PopulateUnitStrings(int slotsToPopulate)
    //{
    //    for (int wordIndex = 0; wordIndex < slotsToPopulate; wordIndex++)
    //    {
    //        var word = BuildWord(queueManager.matchedUnits[wordIndex].spawnChars);
    //        for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
    //        {
    //            Instantiate(word[letterIndex], unitStrings[wordIndex].transform);
    //        }
    //    }
    //}

    private void PopulateUnitStrings(int slotsToPopulate)
    {
        if (slotsToPopulate > 0)
        {
            if (queueManager.matchingUnits)
            {
                for (int wordIndex = 0; wordIndex < slotsToPopulate; wordIndex++)
                {
                    var unit = queueManager.matchedUnits[wordIndex];
                    string unitString = unit.spawnString;
                    unitStrings[wordIndex].text = "<color=\"red\">" + unitString.Substring(0, queueManager.typedLetters.Count) + "<color=\"white\">" + unitString.Substring(queueManager.typedLetters.Count, unitString.Length - queueManager.typedLetters.Count);
                }
            }
            else
            {
                for (int wordIndex = 0; wordIndex < slotsToPopulate; wordIndex++)
                {
                    if (queueManager.queuedUnits.Count > 0)
                    {
                        var unit = queueManager.queuedUnits[wordIndex];
                        string unitString = unit.spawnString;
                        unitStrings[wordIndex].text = unitString;
                    }
                    //TMP_WordInfo info = unitStrings[wordIndex].textInfo.wordInfo[wordIndex];
                    //for (int i = 0; i < queueManager.typedLetters.Count; ++i)
                    //{
                    //    int charIndex = info.firstCharacterIndex + i;
                    //    int meshIndex = unitStrings[wordIndex].textInfo.characterInfo[charIndex].materialReferenceIndex;
                    //    int vertexIndex = unitStrings[wordIndex].textInfo.characterInfo[charIndex].vertexIndex;

                    //    Color32[] vertexColors = unitStrings[wordIndex].textInfo.meshInfo[meshIndex].colors32;
                    //    vertexColors[vertexIndex + 0] = new Color32(255, 255, 255, 255);
                    //}

                    //unitStrings[wordIndex].UpdateVertexData(TMP_VertexDataUpdateFlags.All);
                }
            }
        }
        else
        {
        }
    }

    private void PopulateUnitInfo(int slotsToPopulate)
    {
        if (queueManager.matchingUnits)
        {
            for (int wordIndex = 0; wordIndex < slotsToPopulate; wordIndex++)
            {
                var unit = queueManager.matchedUnits[wordIndex];
                string info = "";
                info += ("Lane: " + unit.laneChoice + "   Type: " + unit.unitChoice);
                unitInfoText[wordIndex].text = info;
            }
        }
        else
        {
            for (int wordIndex = 0; wordIndex < slotsToPopulate; wordIndex++)
            {
                if (queueManager.queuedUnits.Count > 0)
                {
                    var unit = queueManager.queuedUnits[wordIndex];
                    string info = "";
                    info += ("Lane: " + unit.laneChoice + "   Type: " + unit.unitChoice);
                    unitInfoText[wordIndex].text = info;
                }
                else
                {
                }
            }
        }
    }

    private int CalculateSlotsToPopulate()
    {
        int populatedSlots = 0;

        if (queueManager.matchingUnits)
        {
            if (queueManager.matchedUnits.Count >= 10)
            {
                populatedSlots = 10;
            }
            else if (queueManager.matchedUnits.Count > 0)
            {
                populatedSlots = queueManager.matchedUnits.Count;
            }
        }
        else
        {
            if (queueManager.queuedUnits.Count >= 10)
            {
                populatedSlots = 10;
            }
            else if (queueManager.queuedUnits.Count >= 0)
            {
                populatedSlots = queueManager.queuedUnits.Count;
            }
        }

        return populatedSlots;
    }

    private void ClearUnusedSlots(int populatedSlots)
    {
        for (int wordIndex = populatedSlots; wordIndex < 10; wordIndex++)
        {
            //foreach (Transform child in unitStrings[wordIndex].transform)
            //{
            //    Destroy(child);
            //}

            unitInfoText[wordIndex].text = "no unit";
            unitStrings[wordIndex].text = "no string";
        }
    }

    private GameObject[] BuildWord(List<char> letters)
    {
        GameObject[] word = new GameObject[letters.Count];
        for (int letterIndex = 0; letterIndex < word.Length; letterIndex++)
        {
            word[letterIndex] = new GameObject();
            var tmp = word[letterIndex].AddComponent<TextMeshProUGUI>();
            tmp.fontSize = 18;
            tmp.alignment = TextAlignmentOptions.Center;
            var le = word[letterIndex].AddComponent<LayoutElement>();
            le.preferredHeight = 10;
        }

        return word;
    }
}