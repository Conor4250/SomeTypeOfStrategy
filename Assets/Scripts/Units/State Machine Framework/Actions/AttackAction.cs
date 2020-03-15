using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AttackUnit")]
public class AttackAction : UnitAction
{
    public override void Act(UnitStateController controller)
    {
        

        switch (controller.unitBaseStats.attackType)
        {
            case UnitStats.AttackType.standardAttack:
                StandardAttack(controller);
                break;
            case UnitStats.AttackType.wideAttack:
                WideAttack(controller);
                break;
            case UnitStats.AttackType.longAttack:
                LongAttack(controller);
                break;
            case UnitStats.AttackType.boxAttack:
                BoxAttack(controller);
                break;
        }
    }

    private void StandardAttack(UnitStateController controller)
    {

    }
    private void WideAttack(UnitStateController controller)
    {

    }
    private void LongAttack(UnitStateController controller)
    {

    }
    private void BoxAttack(UnitStateController controller)
    {

    }
}
