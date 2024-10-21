using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class IdleState : State
    {
        public IdleState(StateMachine machine) : base(machine) {}

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
        }

        public override void Exit()
        {
            // Debug.Log("Exit Idle");
        }
    }
}

