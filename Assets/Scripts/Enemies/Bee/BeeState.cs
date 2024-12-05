

namespace BeeEnemy
{
    public class BeeState : BaseState
    {
        protected BeeStateMachine machine;

        protected BeeState(BeeStateMachine machine)
        {
            this.machine = machine;
        }

    }
}
