using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsEnemyInRange")]
public class IsEnemyInRange : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return EnemyInRange(controller);
    }

    private bool EnemyInRange(UnitStateController controller)
    {
        for (int i = controller.currentRangeMin; i < controller.currentRangeMax; i++)
        {
            if (controller.currentGrid.GetCellObjects(controller.gridPosX + i*controller.GetPlayerDirection(), 0).Count > 0)
            {
                return true;
            }
        }

        return false;
    }
}

