using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/EnemyAhead")]
public class EnemyAheadUnitDecision : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return EnemyAhead(controller);
    }

    private bool EnemyAhead(UnitStateController controller)
    {
        if(controller.currentLane.CheckNextCellForInhabitant(controller, out UnitStateController detectedController))
        {
            if (detectedController.GetPlayer() == controller.GetPlayer())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
