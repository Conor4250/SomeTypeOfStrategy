using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBrain : MonoBehaviour
{
    public int baseDamage, baseSpeed, baseRange, baseMaxHealth;
    int realDamage, realSpeed, realRange, realMaxHealth;
    int health;
    int level, player;
    int currentExp;
    int expValue;
    UnitState unitState;

    Vector3 moveVector = new Vector3(1,0,0);

    private void Start()
    {
        unitState = UnitState.Waiting;
    }

    void Update()
    {
        switch (unitState)
        {
            case UnitState.Waiting:
                break;
            case UnitState.Moving:
                break;
            case UnitState.Fighting:
                break;
            case UnitState.CastingAbility:
                break;
            case UnitState.Dying:
                break;
        }

        if (player == 1)
            transform.position += moveVector * realSpeed * Time.deltaTime;
        else if (player == 2)
            transform.position -= moveVector * realSpeed * Time.deltaTime;

    }
    public void InitialiseStats()
    {
        realSpeed = baseSpeed * (level + 1);
        realDamage = baseDamage * (level + 1);
        realRange = baseRange * (level + 1);
        realMaxHealth = baseMaxHealth * (level + 1);
    }

    public void setPlayer(int p)
    {
        player = p;
    }

    public void setLevel(int l)
    {
        level = l;
    }

    public void levelUp()
    {
        level++;
    }

    public void gainExperience(int amountGained)
    {

    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public enum UnitState
    {
        Waiting,
        Moving,
        Fighting,
        CastingAbility,
        Dying,
    }
}
