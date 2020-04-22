using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    private int laneChoice, unitChoice;
    public float queuePauseTime = 0.5f;
    public PlayerManager player;
    public PlayerUnitManager unitManager;
    public PlayerCanvasManager canvasManager;

    public InterfaceState interfaceState;
    private bool queueReady = true;
    // Start is called before the first frame update

    public void Init(PlayerManager pm, PlayerUnitManager pum, PlayerCanvasManager pcm)
    {
        Debug.Log(pm.playerNumber + "  PlayerCommands Init Start");
        player = pm;
        unitManager = pum;
        canvasManager = pcm;
        interfaceState = new InterfaceState();
        interfaceState = InterfaceState.root;
        laneChoice = unitChoice = 1;
        Debug.Log(pm.playerNumber + "  PlayerCommands Init Complete");
    }

    public void ProcessCommand(int command)
    {
        switch (interfaceState)
        {
            case InterfaceState.root:
                Root(command);
                Debug.Log("ProcessDefaultState(command);");
                break;

            case InterfaceState.setLane:
                SetLane(command);
                Debug.Log("SetUnitLane(command);");
                break;

            case InterfaceState.setUnit:
                SetUnit(command);
                Debug.Log("SetUnitType(command);");
                break;

            case InterfaceState.abilities:
                Abilities(command);
                Debug.Log("ChooseAbility(command);");
                break;

            case InterfaceState.upgrades:
                Upgrades(command);
                Debug.Log("ChooseUpgrade(command);");
                break;

            default:
                break;
        }

        canvasManager.UpdateCanvases();
    }

    private void Root(int command)
    {
        switch (command)
        {
            case 1:
                if (queueReady)
                {
                    unitManager.queueManager.QueueUnit(laneChoice, unitChoice);
                    StartCoroutine(queuePause());
                }
                break;

            case 2:
                interfaceState = InterfaceState.setLane;
                break;

            case 3:
                interfaceState = InterfaceState.setUnit;
                break;

            case 4:
                interfaceState = InterfaceState.abilities;
                break;

            case 5:
                interfaceState = InterfaceState.upgrades;
                break;

            default:
                break;
        }

        //update UI
    }

    private void SetLane(int command)
    {
        switch (command)
        {
            case 1:
                laneChoice = 1;
                interfaceState = InterfaceState.root;
                break;

            case 2:
                laneChoice = 2;
                interfaceState = InterfaceState.root; ;
                break;

            case 3:
                laneChoice = 3;
                interfaceState = InterfaceState.root;
                break;

            case 4:
                laneChoice = Random.Range(1, 4);
                interfaceState = InterfaceState.root;
                break;

            case 5:
                interfaceState = InterfaceState.root;
                break;

            default:
                break;
        }

        //update UI
    }

    private void SetUnit(int command)
    {
        switch (command)
        {
            case 1:
                unitChoice = 1;
                interfaceState = InterfaceState.root;
                break;

            case 2:
                unitChoice = 2;
                interfaceState = InterfaceState.root; ;
                break;

            case 3:
                unitChoice = 3;
                interfaceState = InterfaceState.root;
                break;

            case 4:
                unitChoice = 4;
                interfaceState = InterfaceState.root;
                break;

            case 5:
                interfaceState = InterfaceState.root;
                break;

            default:
                break;
        }

        //update UI
    }

    private void Abilities(int command)
    {
        switch (command)
        {
            case 1:
                //unitChoice = 1;
                interfaceState = InterfaceState.root;
                break;

            case 2:
                //unitChoice = 2;
                interfaceState = InterfaceState.root; ;
                break;

            case 3:
                //unitChoice = 3;
                interfaceState = InterfaceState.root;
                break;

            case 4:
                //unitChoice = 4;
                interfaceState = InterfaceState.root;
                break;

            case 5:
                interfaceState = InterfaceState.root;
                break;

            default:
                break;
        }

        //update UI
    }

    private void Upgrades(int command)
    {
        switch (command)
        {
            case 1:
                //unitChoice = 1;
                interfaceState = InterfaceState.root;
                break;

            case 2:
                //unitChoice = 2;
                interfaceState = InterfaceState.root; ;
                break;

            case 3:
                //unitChoice = 3;
                interfaceState = InterfaceState.root;
                break;

            case 4:
                //unitChoice = 4;
                interfaceState = InterfaceState.root;
                break;

            case 5:
                interfaceState = InterfaceState.root;
                break;

            default:
                break;
        }

        //update UI
    }

    private IEnumerator queuePause()
    {
        queueReady = false;
        yield return new WaitForSeconds(queuePauseTime);
        queueReady = true;
    }

    public enum InterfaceState
    {
        root,
        setLane,
        setUnit,
        abilities,
        upgrades
    }
}