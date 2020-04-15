using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveUnit")]
public class MoveUnitAction : UnitAction
{
    
    public override void Act(UnitStateController controller)
    {
        MoveToNextCell(controller);
    }

    private void MoveToNextCell(UnitStateController controller)
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