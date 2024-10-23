using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class PatrolState : BoardState
    {
        public PatrolState(StateMachine machine) : base(machine) {}

        public override void Enter()
        {
            Debug.Log("Enter Patrol");

            machine.enemy.anim.Play("Patrol");
        }

        public override void Execute()
        {
            machine.enemy.Patrol();

            if(machine.enemy.IsDetected)
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
}

