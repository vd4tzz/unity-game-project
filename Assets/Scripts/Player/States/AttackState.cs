using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class AttackState : PlayerState
    {
        public AttackState(PlayerStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            // Debug.Log("Enter Attack");
            timer = machine.player.AttackDuration;
            machine.player.anim.Play("Attack");
        }

        public override void Execute()
        {
            machine.player.Attack();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
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

            if(machine.player.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
        
        }

        public override void Exit()
        {
            // Debug.Log("Exit Attack");
        }
    }
}

