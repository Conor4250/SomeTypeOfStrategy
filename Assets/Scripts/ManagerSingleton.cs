using StandardUtilities.ScriptableValues;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    public string[] playerNames;
    public ColorReference[] playerColors;

    public Jar_GridContainer lanes;
    public Jar_GridCell[][] playerSpawnCells;
    public GameObject mainUI, playerCanvasPrefab;

    private PlayerManager[] playerManagers;
    public int playerStartingHealth;

    public GameObject[] unitTypes;

    private static string[] playerKeys;

    private void Start()
    {
        playerKeys = new string[2];
        playerKeys[0] = "qwertasdfzxcv";
        playerKeys[1] = "yuiopghjklbnm";
        playerManagers = new PlayerManager[2];
        playerSpawnCells = lanes.playerSpawnCells;
        InitPlayers();
    }

    private void InitPlayers()
    {
        for (int i = 0; i < 2; i++)
        {
            var playerUICanvas = Instantiate(playerCanvasPrefab, mainUI.transform);

            var player = new GameObject();
            player.name = playerNames[i];
            playerManagers[i] = player.AddComponent<PlayerManager>();

            playerManagers[i].initialisePlayer(this, i + 1, playerNames[i], playerStartingHealth, lanes, playerKeys[i], unitTypes, playerUICanvas, playerSpawnCells[i]);
        }

        for (int i = 0; i < 2; i++)
        {
            playerManagers[i].enemyManager = playerManagers[1 - i];
        }
    }

    public void EndGame(int losingPlayerNumber)
    {
        if (losingPlayerNumber == 1)
        {
        }
        else
        {
        }
    }
}