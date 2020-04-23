using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCanvasManager : MonoBehaviour
{
    public GameObject unitStringCanvas, unitInfoCanvas, commandCanvas;

    private Image[] commandImages;

    private TextMeshProUGUI[] commandText;

    public TextMeshProUGUI[] unitStrings, unitInfoText;
    public GameObject[] commandGOs;
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
        commandImages = new Image[5];
        commandText = new TextMeshProUGUI[5];
        for (int i = 0; i < commandGOs.Length; i++)
        {
            commandImages[i] = commandGOs[i].transform.GetChild(0).GetComponent<Image>();
            commandText[i] = commandGOs[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }
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

                commandImages[0].sprite = uiStorage.rootSelectionImages[0];
                commandImages[1].sprite = uiStorage.rootSelectionImages[1];
                commandImages[2].sprite = uiStorage.rootSelectionImages[2];
                commandImages[3].sprite = uiStorage.rootSelectionImages[3];
                commandImages[4].sprite = uiStorage.rootSelectionImages[4];

                commandGOs[3].SetActive(false);
                commandGOs[4].SetActive(false);
                break;

            case PlayerCommands.InterfaceState.setLane:
                commandText[0].text = uiStorage.laneSelectionText[0];
                commandText[1].text = uiStorage.laneSelectionText[1];
                commandText[2].text = uiStorage.laneSelectionText[2];
                commandText[3].text = uiStorage.laneSelectionText[3];
                commandText[4].text = uiStorage.laneSelectionText[4];

                commandImages[0].sprite = uiStorage.laneSelectionImages[0];
                commandImages[1].sprite = uiStorage.laneSelectionImages[1];
                commandImages[2].sprite = uiStorage.laneSelectionImages[2];
                commandImages[3].sprite = uiStorage.laneSelectionImages[3];
                commandImages[4].sprite = uiStorage.laneSelectionImages[4];

                commandGOs[3].SetActive(true);
                commandGOs[4].SetActive(true);
                break;

            case PlayerCommands.InterfaceState.setUnit:
                commandText[0].text = uiStorage.unitSelectionText[0];
                commandText[1].text = uiStorage.unitSelectionText[1];
                commandText[2].text = uiStorage.unitSelectionText[2];
                commandText[3].text = uiStorage.unitSelectionText[3];
                commandText[4].text = uiStorage.unitSelectionText[4];

                commandImages[0].sprite = uiStorage.unitSelectionImages[0];
                commandImages[1].sprite = uiStorage.unitSelectionImages[1];
                commandImages[2].sprite = uiStorage.unitSelectionImages[2];
                commandImages[3].sprite = uiStorage.unitSelectionImages[3];
                commandImages[4].sprite = uiStorage.unitSelectionImages[4];

                commandGOs[3].SetActive(true);
                commandGOs[4].SetActive(true);
                break;

            default:
                break;
        }
    }

    private void UpdateQueue()
    {
        int slotsToPopulate = CalculateSlotsToPopulate();
        for (int i = 0; i < queueManager.matchedUnits.Count; i++)
        {
            if (queueManager.matchingUnits)
            {
                Debug.Log(queueManager.queuedUnits[i].spawnString);
            }
        }
        PopulateUnitStrings(slotsToPopulate);
        PopulateUnitInfo(slotsToPopulate);
        ClearUnusedSlots(slotsToPopulate);
    }

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
            unitInfoText[wordIndex].text = " ";
            unitStrings[wordIndex].text = " ";
        }
        if (populatedSlots == 0)
        {
            unitInfoText[0].text = "Type what appears";
            unitStrings[0].text = "Queue a unit!";
        }
    }
}