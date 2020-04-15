using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsNextCellOccupied")]
public class IsNextCellOccupied : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return NextCellOccupied(controller);
    }

    private bool NextCellOccupied(UnitStateController controller)
    {
        if (controller.currentGrid.GetCellObjects(controller.gridPosX + 1*controller.GetPlayerDirection(), 0).Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

