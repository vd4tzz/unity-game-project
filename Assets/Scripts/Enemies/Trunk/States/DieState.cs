

namespace Trunk
{
    public class DieState : TrunkState
    {
        public DieState(TrunkStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            
        }

        public override void Execute()
        {
            machine.enemy.InstantiateCoin();
            machine.enemy.DestroyObject();
        }

        public override void Exit()
        {
            
        }
    }
}
