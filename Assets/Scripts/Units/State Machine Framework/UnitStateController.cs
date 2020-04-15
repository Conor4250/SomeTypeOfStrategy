using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    public UnitStats unitBaseStats;
    public int currentDamage, currentSpeed, currentRangeMin, currentRangeMax, currentHealth, currentHealthMax, currentPlayer, currentAttackDelay;
    
    public UnitState currentState, remainState;
    private bool aiActive = false;
    public bool movingToNextCell = false;
    public bool attackReady = true;
    
    public Jar_Grid currentGrid;
    public int gridPosX, gridPosY;
    
    private int directionX = 1;
    
    
    public void Init(QueuedUnit queuedUnit)
    {
        gridPosX = 0;
        gridPosY = 0;
        currentGrid = queuedUnit.grid;
        gameObject.transform.position = currentGrid.GetWorldPosition(0,0);
        currentDamage = unitBaseStats.baseDamage;
        currentHealthMax = unitBaseStats.baseHealth;
        currentRangeMin = unitBaseStats.baseRangeMin;
        currentRangeMax = unitBaseStats.baseRangeMax;
        currentSpeed = unitBaseStats.baseSpeed;
        currentAttackDelay = unitBaseStats.baseAttackDelay;
        currentPlayer = queuedUnit.player;
        if (currentPlayer == 1)
        {
            directionX = 1;
        }
        else
        {
            directionX = -1;
        }
        currentHealth = currentHealthMax;
        aiActive = true;
        
    }

    private void Update()
    {
        if (!aiActive)
        {
            return;
        }
        currentState.UpdateState(this);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, .5f);
        }
    }

    public int GetPlayerDirection()
    {
        return directionX;
    }

    

    public void TransitionToState(UnitState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public void StartAttackDelay(UnitStateController controller)
    {
        StartCoroutine(attackDelay(controller));
    }

    IEnumerator attackDelay(UnitStateController controller)
    {
        yield return new WaitForSeconds(controller.currentAttackDelay);
        attackReady = true;
    }
}
