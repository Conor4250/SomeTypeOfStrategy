using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
public class UnitStats : ScriptableObject
{
    public int baseDamage, baseRangeMin, baseRangeMax, baseHealth, baseAttackDelay;
    public float baseSpeed;

    public AttackType attackType;

    public enum AttackType
    {
        standardAttack,
        wideAttack,
        longAttack,
        boxAttack
    }
}