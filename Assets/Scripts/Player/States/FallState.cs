using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FallState : PlayerState
    {
        public FallState(PlayerStateMachine machine) : base(machine) {}

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
                machine.ChangeState(machine.Idle);
            }
            else if(machine.player.SpaceInput && machine.player.CanDoubleJump)
            {
                machine.ChangeState(machine.DoubleJump);
            }
            else if(machine.player.LeftMouseInput)
            {
                machine.ChangeState(machine.Attack);
            }
            else if(machine.player.Health <= 0)
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

