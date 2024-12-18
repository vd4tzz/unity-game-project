using UnityEngine;


namespace BoardEnemy
{
    public class HitState : BoardState
    {
        public HitState(BoardStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            machine.enemy.anim.Play("Hit");
            timer = machine.enemy.HitDuaration;
        }

        public override void Execute()
        {
            if(timer > 0)
            {
                machine.enemy.Stop();
                timer -= Time.deltaTime;
            }
            else if(machine.enemy.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
            else
            {
                machine.ChangeState(machine.Chase);
            }
        }

        public override void Exit()
        {

        }
    }
}

