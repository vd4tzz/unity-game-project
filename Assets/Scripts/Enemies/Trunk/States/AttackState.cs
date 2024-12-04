using UnityEngine;

namespace Trunk
{
    public class AttackState : TrunkState
    {
        public AttackState(TrunkStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            machine.enemy.anim.Play("Attack");
        }

        public override void Execute()
        {
            machine.enemy.DetectPlayer();
            machine.enemy.Attack();

            if(machine.enemy.IsDetect == false)
            {
                machine.ChangeState(machine.Idle);
            }
            else if(machine.enemy.IsTakingDamage)
            {
                machine.ChangeState(machine.Hit);
            }
            else if(machine.enemy.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
        }

        public override void Exit()
        {
            
        }
    }
}