using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetFoundDecision : UnitDecision
{
    public override bool Decide(UnitStateController controller)
    {
        return EnemyTargetFound(controller);
    }

    private bool EnemyTargetFound(UnitStateController controller)
    {
        return true;
    }


    private List<Vector2> CalculateTargetableCells(UnitStateController controller)
    {
        List<Vector2> targetableCells = new List<Vector2>();
        for (int i = (int)controller.GetRanges().x; i < 3; i++)
        {

        }
        return targetableCells;
    }
}
