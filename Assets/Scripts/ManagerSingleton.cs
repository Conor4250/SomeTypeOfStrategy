using StandardUtilities.ScriptableValues;
using UnityEngine;

public class ManagerSingleton : MonoBehaviour
{
    public string[] playerNames;
    public ColorReference[] playerColors;
    public Jar_GridContainer lanes;
    public Canvas mainUI, playerCanvasPrefab;

    public int playerStartingHealth;

    public GameObject[] unitTypes;

    private static string[] playerKeys;

    private void Start()
    {
        playerKeys = new string[2];
        playerKeys[0] = "qwertasdfzxcv";
        playerKeys[1] = "yuiopghjklbnm";
        InitPlayers();
    }

    private void InitPlayers()
    {
        for (int i = 0; i < 1; i++)
        {
            var player = new GameObject();
            player.name = playerNames[i];

            var playerManager = player.AddComponent<PlayerManager>();

            playerManager.initialisePlayer(this, i, playerNames[i], playerStartingHealth, lanes, playerKeys[i], unitTypes);
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