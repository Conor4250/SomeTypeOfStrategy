using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/NothingAhead")]
public class NothingAheadUnitDecision : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return NothingAhead(controller);
    }

    private bool NothingAhead(UnitStateController controller)
    {
        return controller.currentLane.CheckNextCellForInhabitant(controller, out UnitStateController detectedController);
    }
}
