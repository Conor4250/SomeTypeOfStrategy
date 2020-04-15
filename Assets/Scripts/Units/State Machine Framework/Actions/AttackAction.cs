using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackUnit")]
public class AttackAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        if (controller.attackReady == true)
        {
            controller.attackReady = false;

            switch (controller.unitBaseStats.attackType)
            {
                case UnitStats.AttackType.standardAttack:
                    StandardAttack(controller);
                    break;
                case UnitStats.AttackType.wideAttack:
                    WideAttack(controller);
                    break;
                case UnitStats.AttackType.longAttack:
                    LongAttack(controller);
                    break;
                case UnitStats.AttackType.boxAttack:
                    BoxAttack(controller);
                    break;
            }
        }
    }

    private void StandardAttack(UnitStateController controller)
    {
        for (int i = controller.currentRangeMin; i < controller.currentRangeMax; i++)
        {
            if (controller.currentGrid.GetCellObjects(controller.gridPosX + i * controller.GetPlayerDirection(), 0).Count > 0)
            {
                foreach (GameObject go in controller.currentGrid.GetCellObjects(controller.gridPosX + i * controller.GetPlayerDirection(), 0))
                {
                    UnitStateController enemyController = go.GetComponent<UnitStateController>();
                    enemyController.takeDamage(controller.currentDamage);
                    controller.StartAttackDelay(controller);
                }
                break;
            }
        }
    }
    private void WideAttack(UnitStateController controller)
    {
        
    }
    private void LongAttack(UnitStateController controller)
    {
        
    }
    private void BoxAttack(UnitStateController controller)
    {
        
    }


    
}
