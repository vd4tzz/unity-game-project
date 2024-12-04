using System.Collections;
using System.Collections.Generic;
using Trunk;
using UnityEngine;

namespace Trunk
{
    public class HitState : TrunkState
    {
        public HitState(TrunkStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            machine.enemy.anim.Play("Hit");
            timer = 0.75f;
        }

        public override void Execute()
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                return;
            }

            if(machine.enemy.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
            else
            {
                machine.ChangeState(machine.Idle);
            }
        }

        public override void Exit()
        {
            
        }
    }
}

