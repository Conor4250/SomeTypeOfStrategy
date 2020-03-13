using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Decisions/FriendAhead")]
public class FriendAheadUnitDecision : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return FriendAhead(controller);
    }

    private bool FriendAhead(UnitStateController controller)
    {

        if (controller.currentLane.GetInhabitant(controller.gridPosX + (1 * controller.GetPlayerDirection()), controller.gridPosY) != null)
        {
            if (controller.currentLane.GetInhabitant(controller.gridPosX + (1 * controller.GetPlayerDirection()), controller.gridPosY).GetComponent<UnitStateController>().GetPlayer() == controller.GetPlayer())
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
