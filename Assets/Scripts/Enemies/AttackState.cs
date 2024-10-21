using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    public AttackState(EnemyStateMachine machine) : base(machine) {}

    public override void Enter()
    {
        Debug.Log("Enter Attack");

        machine.enemy.anim.Play("Attack");
    }

    public override void Execute()
    {
        bool status = machine.enemy.Attack();
        if(status == false)
        {
            machine.ChangeState(machine.Patrol);
        }

        if(machine.enemy.IsTakingDamage)
        {
            machine.ChangeState(machine.Hit);
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Attack");
    }

}
