using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnitBrain : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerManager player;

    public PlayerManager enemy;
    public UnitStats unitStats;
    public CurrentState currentState;
    public Cell currentCell, nextCell;
    private bool finalCell = false;
    private Lane currentLane;
    private int moveDir = 1;

    public HealthBar healthBar;
    private Renderer renderComponent;

    public void initBrain(PlayerManager player, PlayerManager enemy, Lane lane, Cell cell, bool aiActive, Color color)
    {
        this.player = player;
        if (player.playerNumber == 1)
        {
            moveDir = 1;
        }
        else
        {
            moveDir = -1;
        }
        this.enemy = enemy;

        renderComponent = gameObject.GetComponent<Renderer>();
        renderComponent.material.SetColor(Shader.PropertyToID("shaderGlowColor"), color);
        currentState = new CurrentState(this, unitStats, healthBar, renderComponent);

        currentLane = lane;
        currentCell = cell;
        currentCell.SetUnit(this);

        CalculateNextCell();

        if (aiActive)
        {
            currentState.aiActive = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (currentState.aiActive)
        {
            //if not moving, check next cell, if empty, set as new cell
            if (!currentState.movingToCell && !finalCell)
            {
                if (!nextCell.containsUnit)
                {
                    currentCell.RemoveUnit();
                    currentCell = nextCell;
                    currentCell.SetUnit(this);

                    for (int i = 0; i < enemy.unitManager.spawnCells.Length; i++)
                    {
                        if (currentCell == enemy.unitManager.spawnCells[i])
                        {
                            finalCell = true;
                        }
                    }
                    CalculateNextCell();
                    currentState.movingToCell = true;
                    transform.DOMove(currentCell.GetWorldPosition(), currentState.moveSpeed);
                }
            }
            else if (currentState.movingToCell) //keep moving and check if youve reached the currentcell position
            {
                if (Vector3.Distance(transform.position, currentCell.GetWorldPosition()) == 0)
                {
                    currentState.movingToCell = false;
                }
            }

            //check for in range enemies
            if (currentState.attackReady)
            {
                if (!finalCell)
                {
                    if (nextCell.containsUnit)
                    {
                        var detectedUnit = nextCell.GetUnit();
                        if (detectedUnit.player == enemy)
                        {
                            detectedUnit.currentState.TakeDamage(currentState.damage, this);
                            currentState.attackReady = false;
                            StartCoroutine(AttackWait());
                        }
                    }
                }
                else
                {
                    enemy.playerHome.takeDamage(currentState.damage);
                    currentState.attackReady = false;
                    StartCoroutine(AttackWait());
                }
            }
        }
    }

    private void CalculateNextCell()
    {
        if (finalCell)
        {
            nextCell = currentCell;
        }
        else
        {
            nextCell = currentLane.GetCell(currentCell.index + moveDir);
        }
    }

    private void Die()
    {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        currentState.aiActive = false;
        player.unitManager.RemoveUnit(this);
        Destroy(gameObject);
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(currentState.attackSpeed);
        currentState.attackReady = true;
    }

    [System.Serializable]
    public struct CurrentState
    {
        public UnitBrain unitBrain;
        public UnitStats initialStats;
        public HealthBar healthBar;
        public int damage, rangeMin, rangeMax, health, healthMax, exp, level, deathExp;
        public float moveSpeed, attackSpeed;
        public int lvlDamage, lvlRange, lvlHealth;
        public float lvlMoveSpeed, lvlAttackSpeed;
        public int[] levelUpExp;
        public bool aiActive, movingToCell, attackReady;
        public Renderer unitRenderer;

        public CurrentState(UnitBrain brain, UnitStats stats, HealthBar hpBar, Renderer renderComponent)
        {
            unitBrain = brain;
            initialStats = stats;
            healthBar = hpBar;
            unitRenderer = renderComponent;

            damage = initialStats.baseDamage;
            rangeMin = initialStats.baseRangeMin;
            rangeMax = initialStats.baseRangeMax;
            healthMax = initialStats.baseHealth;
            deathExp = initialStats.deathExp;
            attackSpeed = initialStats.baseAttackDelay;
            moveSpeed = initialStats.baseSpeed;

            health = healthMax;
            exp = 0;
            level = 0;

            levelUpExp = initialStats.lvlUpExp;
            lvlDamage = initialStats.lvlDamage;
            lvlRange = initialStats.lvlRange;
            lvlHealth = initialStats.lvlHealth;
            lvlMoveSpeed = initialStats.lvlSpeed;
            lvlAttackSpeed = initialStats.lvlAttackDelay;

            attackReady = true;
            movingToCell = false;
            healthBar.SetMaxHealth(healthMax);

            aiActive = false;
        }

        public void GainExp(int amount)
        {
            exp += amount;
            if (level < 3)
            {
                if (exp > levelUpExp[level + 1])
                {
                    LevelUp();
                }
            }
        }

        private void LevelUp()
        {
            level++;
            damage += lvlDamage;
            rangeMax += lvlRange;
            healthMax += lvlHealth;
            moveSpeed += lvlMoveSpeed;
            attackSpeed += lvlAttackSpeed;
        }

        public void TakeDamage(int damage, UnitBrain damager)
        {
            var damageFlashStart = unitRenderer.material.DOColor(Color.red, 0.1f);
            var damageFlashEnd = unitRenderer.material.DOColor(Color.white, 0.9f).SetDelay(0.1f);

            health -= damage;
            unitBrain.healthBar.SetHealth(health);

            if (health <= 0)
            {
                damager.currentState.GainExp(deathExp);
                DOTween.Complete(damageFlashStart);
                DOTween.Complete(damageFlashEnd);
                unitBrain.Die();
            }
        }
    }
}