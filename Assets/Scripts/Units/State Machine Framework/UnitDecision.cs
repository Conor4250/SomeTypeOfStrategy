using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitDecision : ScriptableObject
{
    public abstract bool Decide(UnitStateController controller);
}