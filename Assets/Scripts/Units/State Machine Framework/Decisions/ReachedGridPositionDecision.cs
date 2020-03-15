using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ReachedGridPosition")]
public class ReachedGridPositionDecision : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return ReachedGridPosition(controller);
    }

    private bool ReachedGridPosition(UnitStateController controller)
    {
        if (Vector3.Distance(controller.gameObject.transform.position, controller.currentGrid.GetWorldPosition(controller.gridPosX, controller.gridPosY)) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
