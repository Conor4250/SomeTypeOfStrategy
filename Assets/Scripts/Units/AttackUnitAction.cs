using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackUnit")]
public class AttackUnitAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        AttackNextXCell(controller);
    }

    private void AttackNextXCell(UnitStateController controller)
    {
        controller.currentLane.GetInhabitant(controller.gridPosX + 1 * controller.GetPlayerDirection(), controller.gridPosY).GetComponent<UnitStateController>().takeDamage(controller.GetPlayer());
    }
}
