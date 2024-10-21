using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HitState : EnemyState
{
    public HitState(EnemyStateMachine machine) : base(machine) {}

    private float timer;

    public override void Enter()
    {
        machine.enemy.anim.Play("Hit");
        timer = 0.3f;
    }

    public override void Execute()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(machine.enemy.Health <= 0)
        {
            machine.ChangeState(machine.Die);
        }
        else
        {
            machine.ChangeState(machine.Attack);
        }
    }

    public override void Exit()
    {

    }
}
