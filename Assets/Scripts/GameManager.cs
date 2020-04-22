using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] playerNames;
    public string[] playerKeys;
    public GameObject[] playerHomes;

    public PlayerManager[] players;

    //private PlayerUnitManager[] unitManagers;
    public int playerStartingHealth;

    public GameObject[] levelUnits;

    public LaneContainer lanes;
    public GameObject mainUI;
    public GameObject[] playerUIs;

    private void Start()
    {
        Debug.Log("Game Manager Init Start");
        playerKeys[0] = "qwertasdfzxcv";
        playerKeys[1] = "yuiopghjklbnm";
        InitPlayer(0);
        InitPlayer(1);
        players[0].enemy = players[1];
        players[1].enemy = players[0];
        Debug.Log("Game Manager Init Complete");
    }

    private void InitPlayer(int playerIndex)
    {
        var player = new GameObject();
        player.name = playerNames[playerIndex];
        players[playerIndex] = player.AddComponent<PlayerManager>();

        players[playerIndex].Init(this, playerIndex + 1, playerNames[playerIndex], playerStartingHealth, lanes, playerKeys[playerIndex], levelUnits, mainUI, playerUIs[playerIndex], playerHomes[playerIndex]);
    }

    // Update is called once per frame
    public void EndGame(PlayerManager loser)
    {
    }
}