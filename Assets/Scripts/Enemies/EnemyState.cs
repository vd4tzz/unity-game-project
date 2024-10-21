using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateMachine machine;

    protected EnemyState(EnemyStateMachine machine)
    {
        this.machine = machine;
    }
    
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
