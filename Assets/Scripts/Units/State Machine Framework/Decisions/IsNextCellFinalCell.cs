using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsNextCellFinalCell")]
public class IsNextCellFinalCell : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return NextCellFinalCell(controller);
    }

    private bool NextCellFinalCell(UnitStateController controller)
    {
        if (controller.currentGrid.GetCell(controller.gridPosX + (1 * controller.GetPlayerDirection()), 0) == controller.playerManager.playerSpawnCells[controller.laneIndex])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}