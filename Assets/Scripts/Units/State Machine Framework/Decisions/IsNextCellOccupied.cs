using System;
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
        if (controller.GetNextCell().GetEndCell())
        {
            return true;
        }
        else
        {
            return controller.GetNextCell().ContainsUnit();
        }
    }
}