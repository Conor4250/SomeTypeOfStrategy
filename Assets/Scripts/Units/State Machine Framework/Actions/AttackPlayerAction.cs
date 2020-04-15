using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackPlayer")]
public class AttackPlayerAction : UnitAction
{

    public override void Act(UnitStateController controller)
    {
        AttackPlayer(controller);
    }

    private void AttackPlayer(UnitStateController controller)
    {
        if (controller.movingToNextCell == false)
        {
            controller.gridPosX += controller.GetPlayerDirection();
            controller.movingToNextCell = true;
        }
        else
        {
            controller.gameObject.transform.position = Vector3.MoveTowards(controller.gameObject.transform.position, controller.currentGrid.GetWorldPosition(controller.gridPosX, controller.gridPosY), controller.currentSpeed);
        }
    }
}