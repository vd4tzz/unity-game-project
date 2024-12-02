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
            Debug.Log("Enter Move");
            machine.player.anim.Play("Move");
        }

        public override void Execute()
        {
            machine.player.Move();

            if(machine.player.XInput == 0)
            {
                machine.ChangeState(machine.Idle);
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
            Debug.Log("Exit Move");
        }
    }
}

