using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DoubleJumpState : State
    {
        public DoubleJumpState(StateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            // Debug.Log("Enter DoubleJump");
            machine.player.anim.Play("DoubleJump");
            timer = machine.player.DoulbeJumpDuration;
        }

        public override void Execute()
        {
            machine.player.DoubleJump();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Fall);
            }
        }

        public override void Exit()
        {
            // Debug.Log("Exit DoubleJump");
        }
    }
}

