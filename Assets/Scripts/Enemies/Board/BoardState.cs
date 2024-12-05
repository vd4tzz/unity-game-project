

namespace BoardEnemy
{
    public class BoardState : BaseState
    {
        protected BoardStateMachine machine;

        protected BoardState(BoardStateMachine machine)
        {
            this.machine = machine;
        }
    }
}

