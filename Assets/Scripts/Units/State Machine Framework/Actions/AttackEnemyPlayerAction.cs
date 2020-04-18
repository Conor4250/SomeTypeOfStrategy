using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackEnemyPlayer")]
public class AttackEnemyPlayerAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        AttackEnemyPlayer(controller);
    }

    private void AttackEnemyPlayer(UnitStateController controller)
    {
        if (controller.attackReady)
        {
            controller.playerManager.enemyManager.damagePlayer(controller.currentDamage);
            controller.StartAttackDelay();
        }
    }
}