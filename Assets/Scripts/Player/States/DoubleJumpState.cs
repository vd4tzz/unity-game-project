using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class DoubleJumpState : State
    {
        public DoubleJumpState(StateMachine machine) : base(machine) {}

        private float doubleJumpTimer;

        public override void Enter()
        {
            Debug.Log("Enter DoubleJump");
            machine.player.anim.Play("DoubleJump");
            doubleJumpTimer = 0.1f;
        }

        public override void Execute()
        {
            machine.player.DoubleJump();
            if(doubleJumpTimer > 0)
            {
                doubleJumpTimer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Fall);
            }


            
        }

        public override void Exit()
        {
            Debug.Log("Exit DoubleJump");
        }
    }
}

