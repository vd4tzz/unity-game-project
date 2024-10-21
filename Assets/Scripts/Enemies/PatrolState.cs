using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public PatrolState(EnemyStateMachine machine) : base(machine) {}

    public override void Enter()
    {
        Debug.Log("Enter Patrol");

        machine.enemy.anim.Play("Patrol");
    }

    public override void Execute()
    {
        machine.enemy.Patrol();

        if(machine.enemy.DetectPlayer())
        {
            machine.ChangeState(machine.Detect);
        }
        
        if(machine.enemy.IsTakingDamage)
        {
            machine.ChangeState(machine.Hit);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Patrol");
    }

}
