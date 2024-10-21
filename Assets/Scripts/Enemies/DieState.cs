using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : EnemyState
{
    public DieState(EnemyStateMachine machine) : base(machine) {}

    public override void Enter()
    {

    }

    public override void Execute()
    {
        machine.enemy.DestroyObject();
    }

    public override void Exit()
    {

    }
}
