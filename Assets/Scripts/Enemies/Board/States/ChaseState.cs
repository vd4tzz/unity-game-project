using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class ChaseState : BoardState
    {
        public ChaseState(BoardStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            Debug.Log("Enter Chase");

            machine.enemy.anim.Play("Chase");
        }

        public override void Execute()
        {
            machine.enemy.Chase();
            
            if(!machine.enemy.IsChasing)
            {
                machine.ChangeState(machine.Patrol);
            }
            else if(machine.enemy.IsTakingDamage)
            {
                machine.ChangeState(machine.Hit);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Chase");
        }

    }
}

