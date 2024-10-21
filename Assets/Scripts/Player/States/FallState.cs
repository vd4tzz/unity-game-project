using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FallState : State
    {
        public FallState(StateMachine machine) : base(machine) {}

        private bool canDoubleJump;

        public override void Enter()
        {
            // Debug.Log("Enter Fall");
            machine.player.anim.Play("Fall");
        }

        public override void Execute()
        {
            machine.player.Fall();
            machine.player.Move();


            if(machine.player.IsGrounded)
            {
                canDoubleJump = true;
                machine.ChangeState(machine.Idle);
            }

            if(machine.player.SpaceInput && canDoubleJump)
            {
                machine.ChangeState(machine.DoubleJump);
                canDoubleJump = false;
            }

            if(machine.player.LeftMouseInput)
            {
                machine.ChangeState(machine.Attack);
            }
        }

        public override void Exit()
        {
            // Debug.Log("Exit Fall");
        }
    }
}

