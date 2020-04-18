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
        if (Vector3.Distance(controller.gameObject.transform.position, controller.GetCurrentCell().GetWorldPosition()) == 0)
        {
            controller.movingToNextCell = false;
            Debug.Log("target cell is reached - true");
            return true;
        }
        else
        {
            controller.movingToNextCell = true;
            Debug.Log("target cell is reached - false");
            return false;
        }
    }
}