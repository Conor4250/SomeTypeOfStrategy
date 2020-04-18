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
            if (controller.CurrentGrid.GetCell(controller.GetCurrentCell().cellIndexX + (i * controller.DirectionX), 0).ContainsUnit())
            {
                Debug.Log("EnemyInRange - true ");
                return true;
            }
        }
        Debug.Log("EnemyInRange - false");
        return false;
    }
}