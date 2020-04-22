using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHome : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerManager player;
    private Color playerColor;
    private Renderer ren;

    [SerializeField]
    private int health;

    private int healthMax;

    public void Init(GameManager gm, PlayerManager player, int healthMax, Color color)
    {
        gameManager = gm;
        this.player = player;
        this.healthMax = healthMax;
        health = this.healthMax;
        playerColor = color;
        ren = gameObject.GetComponent<Renderer>();
        ren.material.SetColor(Shader.PropertyToID("shaderGlowColor"), playerColor);
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