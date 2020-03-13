using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveUnit")]
public class MoveUnitAction : UnitAction
{
    bool stillMoving = false;
    public override void Act(UnitStateController controller)
    {

        if (stillMoving)
        {
            MoveToNextCell(controller);
        }
        else
        {
            controller.currentLane.MoveInhabitantToNextCell(controller);
            stillMoving = true;
        }
    }

    private void MoveToNextCell(UnitStateController controller)
    {
        Debug.Log("Moving");

        Vector3 destination;
        destination = controller.currentLane.GetWorldPosition(controller.gridPosX, controller.gridPosY);

        if (Vector3.Distance(controller.transform.position, destination) > 0.001f)
        {
            Debug.Log("Traveling towards the waypoint");
            controller.transform.position = Vector3.MoveTowards(controller.transform.position, destination, controller.GetPlayerSpeed() * Time.deltaTime);
            
        }
        else
        {
            stillMoving = false;
            Debug.Log("Already in that cell");
        }
    }
}