using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AttackState : State
    {
        public AttackState(StateMachine machine) : base(machine) {}

        private float attackTimer;

        public override void Enter()
        {
            Debug.Log("Enter Attack");
            attackTimer = 0.35f;
            machine.player.anim.Play("Attack");
        }

        public override void Execute()
        {
            machine.player.Attack();
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                if(machine.player.LeftMouseInput)
                {
                    machine.ChangeState(machine.Attack2);
                }

            }
            else 
            {
                if(machine.player.IsGrounded)
                {
                    machine.ChangeState(machine.Idle);
                }
                else
                {
                    machine.ChangeState(machine.Fall);
                }
                
            }
        
        }

        public override void Exit()
        {
            Debug.Log("Exit Attack");
        }
    }
}

