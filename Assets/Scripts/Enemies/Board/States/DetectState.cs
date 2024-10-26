using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class DetectState : BoardState
    {
        public DetectState(BoardStateMachine machine) : base(machine) {}
        
        float timer;
        public override void Enter() 
        {   
            Debug.Log("Enter Detect");

            machine.enemy.anim.Play("Detect");
            timer = machine.enemy.DetectDuration;
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

            if(machine.enemy.IsTakingDamage)
            {
                machine.ChangeState(machine.Hit);
            }
        }

        public override void Exit() 
        {
            Debug.Log("Exit Detect");
        }

    }
}

