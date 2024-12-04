using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeEnemy
{
    public class DetectState : BeeState
    {
        public DetectState(BeeStateMachine machine) : base(machine) {}

        float timer;

        public override void Enter()
        {
            Debug.Log("Enter Detect bee");
            timer = machine.enemy.DetectDuration;
            timer = 0.3f;
        }

        public override void Execute()
        {
            machine.enemy.Stop();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Chase);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit DDetect bee");
        }
    }
}


