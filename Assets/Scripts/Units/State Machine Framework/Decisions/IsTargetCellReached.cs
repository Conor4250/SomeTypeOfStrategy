using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsTargetCellReached")]
public class IsTargetCellReached : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return TargetCellReached(controller);
    }

    private bool TargetCellReached(UnitStateController controller)
    {
        if (Vector3.Distance(controller.gameObject.transform.position, controller.currentGrid.GetWorldPosition(controller.gridPosX, controller.gridPosY)) == 0)
        {
            controller.movingToNextCell = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
