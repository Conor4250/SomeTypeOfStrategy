using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHome : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerManager player;

    [SerializeField]
    private int health;

    private int healthMax;

    public void Init(GameManager gm, PlayerManager player, int healthMax)
    {
        gameManager = gm;
        this.player = player;
        this.healthMax = healthMax;
        health = this.healthMax;
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            gameManager.EndGame(player);
        }
    }
}