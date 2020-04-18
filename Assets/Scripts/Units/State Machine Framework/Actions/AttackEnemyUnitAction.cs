using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackEnemyUnitAction")]
public class AttackEnemyUnitAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        if (controller.attackReady == true)
        {
            controller.attackReady = false;
            var gridCells = controller.CurrentGrid.GetAllCells();

            switch (controller.attackType)
            {
                case UnitStats.AttackType.standardAttack:
                    StandardAttack(controller, gridCells);
                    break;

                case UnitStats.AttackType.wideAttack:
                    WideAttack(controller, gridCells);
                    break;

                case UnitStats.AttackType.longAttack:
                    LongAttack(controller, gridCells);
                    break;

                case UnitStats.AttackType.boxAttack:
                    BoxAttack(controller, gridCells);
                    break;
            }
        }
    }

    private void StandardAttack(UnitStateController controller, Jar_GridCell[,] gridCells)
    {
        for (int i = controller.currentRangeMin; i < controller.currentRangeMax; i++)
        {
            if (gridCells[i, 0].ContainsUnit())
            {
                var detectedEnemy = gridCells[i, 0].GetUnit();
                detectedEnemy.takeDamage(controller.currentDamage);
                controller.StartAttackDelay();
                break;
            }
        }
    }

    private void WideAttack(UnitStateController controller, Jar_GridCell[,] gridCells)
    {
    }

    private void LongAttack(UnitStateController controller, Jar_GridCell[,] gridCells)
    {
    }

    private void BoxAttack(UnitStateController controller, Jar_GridCell[,] gridCells)
    {
    }
}