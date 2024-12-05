

namespace Player
{
    public abstract class PlayerState : BaseState
    {
        protected PlayerStateMachine machine;

        protected PlayerState(PlayerStateMachine machine)
        {
            this.machine = machine;
        }
    }
}


