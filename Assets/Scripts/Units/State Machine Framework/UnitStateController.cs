using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    public PlayerManager playerManager;

    public UnitStats unitBaseStats;
    public UnitStats.AttackType attackType;
    public int currentDamage, currentRangeMin, currentRangeMax, currentHealth, currentHealthMax, currentPlayer, currentAttackDelay;
    public float currentSpeed;

    public UnitState currentState, remainState;
    public bool aiActive = false;
    public bool movingToNextCell = false;
    public bool attackReady = true;

    private Jar_Grid currentGrid;

    private Jar_GridCell previousCell, currentCell, nextCell;
    private int gridPosX, gridPosY, laneIndex;

    private int directionX = 1;

    public void Init(QueuedUnit queuedUnit)
    {
        currentGrid = queuedUnit.grid;
        laneIndex = currentGrid.GridIndex;
        playerManager = queuedUnit.playerManager;
        currentPlayer = playerManager.playerNumber;

        if (currentPlayer == 1)
        {
            directionX = 1;
        }
        else
        {
            directionX = -1;
        }

        SetCurrentCell(playerManager.playerSpawnCells[laneIndex]);
        SetWorldPosition(currentCell.GetWorldPosition());
        InitialiseStats(unitBaseStats);

        playerManager = queuedUnit.playerManager;
        currentPlayer = queuedUnit.playerManager.playerNumber;

        currentHealth = currentHealthMax;
        aiActive = true;
    }

    private void InitialiseStats(UnitStats unitBaseStats)
    {
        attackType = unitBaseStats.attackType;
        currentDamage = unitBaseStats.baseDamage;
        currentHealthMax = unitBaseStats.baseHealth;
        currentRangeMin = unitBaseStats.baseRangeMin;
        currentRangeMax = unitBaseStats.baseRangeMax;
        currentSpeed = unitBaseStats.baseSpeed;
        currentAttackDelay = unitBaseStats.baseAttackDelay;
    }

    private void Update()
    {
        if (!aiActive)
        {
            return;
        }
        currentState.UpdateState(this);

        transform.position = Vector3.MoveTowards(transform.position, currentGrid.GetWorldPosition(gridPosX, gridPosY), currentSpeed);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public int DirectionX
    {
        get
        {
            return directionX;
        }
        set
        {
            directionX = value;
        }
    }

    public void SetWorldPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void SetCurrentCell(Jar_GridCell newCell)
    {
        if (currentCell != null)
        {
            currentCell.RemoveUnit();
        }
        currentCell = newCell;
        currentCell.AddUnit(this);

        nextCell = currentCell.GetNeighbourCell(directionX);
        previousCell = currentCell.GetNeighbourCell(-directionX);

        gridPosX = currentCell.cellIndexX;
        gridPosY = currentCell.cellIndexY;
    }

    public Jar_GridCell GetCurrentCell()
    {
        return currentCell;
    }

    public Jar_GridCell GetNextCell()
    {
        return nextCell;
    }

    public Jar_GridCell GetPreviousCell()
    {
        return previousCell;
    }

    public Jar_Grid CurrentGrid
    {
        get
        {
            return currentGrid;
        }
        set
        {
            currentGrid = value;
        }
    }

    public void TransitionToState(UnitState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public void StartAttackDelay()
    {
        StartCoroutine(attackDelay());
    }

    private IEnumerator attackDelay()
    {
        yield return new WaitForSeconds(currentAttackDelay);
        attackReady = true;
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, .5f);
        }
    }
}