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
            machine.player.anim.Play("Idle");
            Debug.Log("Enter Hit");
            machine.player.Stop();
            machine.player.SetVelocity(8 * machine.player.AttackedDirection, 3);
            timer = 0.6f;
        }

        public override void Execute()
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log("7gao");
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

