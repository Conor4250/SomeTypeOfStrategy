using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class UnitState : ScriptableObject
{
    public UnitAction[] actions;
    public UnitTransition[] transitions;
    public Color sceneGizmoColor = Color.gray;

    public void UpdateState(UnitStateController controller)
    {
        DoActions(controller);
        CheckTransition(controller);
    }

    private void DoActions(UnitStateController controller)
    {
        foreach (UnitAction action in actions)
        {
            action.Act(controller);
        }
    }

    private void CheckTransition(UnitStateController controller)
    {
        foreach (UnitTransition transition in transitions)
        {
            bool decisionSucceeded = transition.decision.Decide(controller);
            controller.TransitionToState(decisionSucceeded ? transition.trueState : transition.falseState);
        }
    }
}