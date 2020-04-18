using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveToNextCell")]
public class MoveToNextCellAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        MoveToNextCell(controller);
    }

    private void MoveToNextCell(UnitStateController controller)
    {
        if (controller == null)
        {
            Debug.Log("controller is null");
        }
        else if (controller.GetNextCell() == null)
        {
            Debug.Log("controller.GetNextCell() is null");
        }

        if (controller.movingToNextCell == false && !controller.GetNextCell().ContainsUnit())
        {
            controller.SetCurrentCell(controller.GetNextCell());
        }
    }
}