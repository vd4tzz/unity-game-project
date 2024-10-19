using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class JumpState : State
    {
        public JumpState(StateMachine machine) : base(machine) {}

        private float jumpTimer;

        public override void Enter()
        {
            Debug.Log("Enter Jump");
            machine.player.anim.Play("Jump");
            jumpTimer = machine.player.JumpDuration;
        }

        public override void Execute()
        {
            machine.player.Jump();
            machine.player.Move();


            if(jumpTimer > 0)
            {
                jumpTimer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Fall);
            }

            if(machine.player.SpaceInput)
            {
                machine.ChangeState(machine.DoubleJump);
            }

            if(machine.player.LeftMouseInput)
            {
                machine.ChangeState(machine.Attack);
            }
        
        }

        public override void Exit()
        {
            Debug.Log("Exit Jump");
        }
    }
}

