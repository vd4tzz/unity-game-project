using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FallState : PlayerState
    {
        public FallState(PlayerStateMachine machine) : base(machine) {}

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

            if(machine.player.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
        }

        public override void Exit()
        {
            // Debug.Log("Exit Fall");
        }
    }
}

