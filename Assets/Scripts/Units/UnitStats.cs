using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/EnemyStats")]
public class UnitStats : ScriptableObject
{
    public int baseDamage, baseRangeMin, baseRangeMax, baseHealth;
    public float baseSpeed, baseAttackDelay;

    public int deathExp;

    public int[] lvlUpExp;

    public int lvlDamage, lvlRange, lvlHealth;
    public float lvlSpeed, lvlAttackDelay;

    public Material unitMat;

    //public AttackType attackType;

    //public enum AttackType
    //{
    //    standardAttack,
    //    wideAttack,
    //    longAttack,
    //    boxAttack
    //}
}