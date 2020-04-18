//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "PluggableAI/Decisions/IsAbleToAdvance")]
//public class IsAbleToAdvance : UnitDecision
//{
//    public override bool Decide(UnitStateController controller)
//    {
//        return AbleToAdvance(controller);
//    }

//    private bool AbleToAdvance(UnitStateController controller)
//    {
//        int nextGridCellIndex = controller.currentGrid.gridIndex + (1 * controller.GetPlayerDirection());
//        Jar_GridCell nextCell = controller.currentGrid.gridCellArray[nextGridCellIndex, 0];

//        Debug.Break();
//        if (nextCell.containsEntity || IsNextCellFinalCell.NextCellFinalCell(controller))
//        {
//            Debug.Log("next cell is occupied - true");
//            return true;
//        }
//        else
//        {
//            Debug.Log("next cell is occupied - false");
//            return false;
//        }
//    }
//}