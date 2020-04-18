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

    public static bool NextCellFinalCell(UnitStateController controller)
    {
        return controller.GetNextCell().GetEndCell();
    }
}