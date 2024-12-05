using UnityEngine;


namespace BeeEnemy
{
    public class PatrolState : BeeState
    {
        public PatrolState(BeeStateMachine machine) : base(machine) {}

        public override void Enter()
        {
           Debug.Log("Enter Patrol bee");
        }

        public override void Execute()
        {
            machine.enemy.Patrol();

            if(machine.enemy.IsDetected)
            {
                machine.ChangeState(machine.Detect);
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Patrol bee");
        }
    }
}

