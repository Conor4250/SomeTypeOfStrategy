using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAction : ScriptableObject
{
    public abstract void Act(UnitStateController controller);
}
