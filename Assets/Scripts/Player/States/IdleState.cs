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
            Debug.Log("Enter Idle");
            machine.player.anim.Play("Idle");
        }

        public override void Execute()
        {
            if(machine.player.XInput != 0)
            {
                machine.ChangeState(machine.Move);
            }
            else if(machine.player.SpaceInput)
            {
                machine.ChangeState(machine.Jump);
            }
            else if(machine.player.LeftMouseInput)
            {
                machine.ChangeState(machine.Attack);
            }
            else if(machine.player.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
            else if(machine.player.IsTakingDamage)
            {
                machine.ChangeState(machine.Hit);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Idle");
        }
    }
}

