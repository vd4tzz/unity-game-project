using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BeeEnemy
{
    public class ChaseState : BeeState
    {
        public ChaseState(BeeStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            Debug.Log("Enter Attack bee");
        }

        public override void Execute()
        {
           machine.enemy.Chase();

           if(!machine.enemy.IsChasing)
           {
                machine.ChangeState(machine.Patrol);
           }
        }

        public override void Exit()
        {
            Debug.Log("Exit Attack bee");
        }
    }
}
