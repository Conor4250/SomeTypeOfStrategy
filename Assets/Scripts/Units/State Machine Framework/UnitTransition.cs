using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitTransition
{
    public UnitDecision decision;
    public UnitState trueState;
    public UnitState falseState;
}

