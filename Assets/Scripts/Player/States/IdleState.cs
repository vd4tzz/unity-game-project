using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : PlayerState
    {
        public IdleState(PlayerStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            // Debug.Log("Enter Idle");
            machine.player.anim.Play("Idle");
        }

        public override void Execute()
        {
            if(machine.player.XInput != 0)
            {
                machine.ChangeState(machine.Move);
            }

            if(machine.player.SpaceInput)
            {
                machine.ChangeState(machine.Jump);
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
            // Debug.Log("Exit Idle");
        }
    }
}

