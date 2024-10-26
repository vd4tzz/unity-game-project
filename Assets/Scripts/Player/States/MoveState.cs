using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class MoveState : PlayerState
    {
        public MoveState(PlayerStateMachine machine) : base(machine) {}
        
        public override void Enter()
        {
            // Debug.Log("Enter Move");
            machine.player.anim.Play("Move");
        }

        public override void Execute()
        {
            machine.player.Move();

            if(machine.player.XInput == 0)
            {
                machine.ChangeState(machine.Idle);
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
            // Debug.Log("Exit Move");
        }
    }
}

