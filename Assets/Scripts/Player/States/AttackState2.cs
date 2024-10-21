using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{
    public class AttackState2 : State
    {
        public AttackState2(StateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            // Debug.Log("Enter Attack2");
            timer = machine.player.AttackDuration;
            machine.player.anim.Play("Attack2");
        }

        public override void Execute()
        {
            machine.player.Attack();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
                if(machine.player.LeftMouseInput)
                {
                    machine.ChangeState(machine.Attack);
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
            // Debug.Log("Exit Attack2");
        }
    }
}

