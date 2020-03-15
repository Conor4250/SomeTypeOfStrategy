using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : MonoBehaviour
{
    public UnitStats unitBaseStats;
    public UnitState currentState, remainState;
    private bool aiActive = false;
    private int currentDamage, currentSpeed, currentRangeMin, currentRangeMax, currentHealth, currentHealthMax, currentPlayer, directionX =1;
    public Lane currentLane;
    public int gridPosX, gridPosY;
    //public LaneContainer laneContainer;


    private void Awake()
    {
        gridPosX = 0;
        gridPosY = 0;
    }

    public void Init(QueuedUnit queuedUnit)
    {
        gridPosX = 0;
        gridPosY = 0;
        currentLane = queuedUnit.laneContainer.lanes[queuedUnit.laneIndex];
        gameObject.transform.position = currentLane.GetWorldPosition(0,0);
        currentDamage = unitBaseStats.baseDamage;
        currentHealthMax = unitBaseStats.baseHealth;
        currentRangeMin = unitBaseStats.baseRangeMin;
        currentRangeMax = unitBaseStats.baseRangeMax;
        currentSpeed = unitBaseStats.baseSpeed;
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
            Gizmos.DrawWireSphere(this.transform.position, .5f);
        }
    }

    public int GetPlayerDirection()
    {
        return directionX;
    }

    public int GetPlayer()
    {
        return currentPlayer;
    }

    public int GetPlayerSpeed()
    {
        return currentSpeed;
    }

    public Vector2 GetRanges()
    {
        return new Vector2(currentRangeMin,currentRangeMax);
    }

    public void TransitionToState(UnitState nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
