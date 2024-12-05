using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class HitState : PlayerState
    {
        public HitState(PlayerStateMachine machine) : base(machine) { }

        private float timer;

        public override void Enter()
        {
            machine.player.anim.Play("Hit");
            machine.player.Stop();
            machine.player.SetForce(5 * machine.player.AttackedDirection, 3);
            timer = 0.6f;
        }

        public override void Execute()
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
                machine.ChangeState(machine.Idle);

        }

        public override void Exit()
        {
            Debug.Log("Exit Hit");
        }
    }
}

