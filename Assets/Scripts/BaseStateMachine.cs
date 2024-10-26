using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine
{
    protected IState currentState;

    public virtual void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public virtual void Update()
    {
        currentState.Execute();
    }
}
