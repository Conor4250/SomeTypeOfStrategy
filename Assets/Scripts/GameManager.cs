using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public SceneSwitcher sceneSwitcher;
    private string[] playerNames;
    private string[] playerKeys;
    private Color[] playerColors;

    public GameObject[] playerHomes;

    public PlayerManager[] players;

    //private PlayerUnitManager[] unitManagers;
    public int playerStartingHealth;

    public GameObject[] levelUnits;

    public LaneContainer lanes;
    public GameObject mainUI;
    public GameObject[] playerUIs;
    public GameObject endUI;

    private void Start()
    {
        Debug.Log("Game Manager Init Start");
        playerKeys = new string[2];
        playerKeys[0] = gameSettings.playerOneKeys;
        playerKeys[1] = gameSettings.playerTwoKeys;
        playerNames = new string[2];
        playerNames[0] = gameSettings.playerOneName;
        playerNames[1] = gameSettings.playerTwoName;
        playerColors = new Color[2];
        playerColors[0] = gameSettings.playerOneColor;
        playerColors[1] = gameSettings.playerTwoColor;
        InitPlayer(0);
        InitPlayer(1);
        players[0].enemy = players[1];
        players[1].enemy = players[0];
        Debug.Log("Game Manager Init Complete");
    }

    private void InitPlayer(int i)
    {
        var player = new GameObject();
        player.name = playerNames[i];
        players[i] = player.AddComponent<PlayerManager>();

        players[i].Init(this, i + 1, playerNames[i], playerStartingHealth, lanes, playerKeys[i], levelUnits, mainUI, playerUIs[i], playerHomes[i], playerColors[i]);
    }

    // Update is called once per frame
    public void EndGame(PlayerManager loser)
    {
        var endCanvas = Instantiate(endUI);

        var endScreen = endCanvas.GetComponent<EndScreen>();
        endScreen.endText.text = (loser.enemy.playerName + " Wins!");
        StartCoroutine(EndWait());
    }

    public IEnumerator EndWait()
    {
        yield return new WaitForSeconds(3f);
        sceneSwitcher.LoadScene(0);
    }
}