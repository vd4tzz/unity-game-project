

namespace Trunk
{
    public class IdleState : TrunkState
    {
        public IdleState(TrunkStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            machine.enemy.anim.Play("Idle");
        }

        public override void Execute()
        {
            machine.enemy.DetectPlayer();

            if(machine.enemy.IsDetect)
            {
                machine.ChangeState(machine.Attack);
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