using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
public class UnitStats : ScriptableObject
{
    public int baseDamage, baseSpeed, baseRangeMin, baseRangeMax, baseHealth, baseAttackRate;
    public AttackType attackType;

    public enum AttackType
    {
        standardAttack,
        wideAttack,
        longAttack,
        boxAttack
    }
}
