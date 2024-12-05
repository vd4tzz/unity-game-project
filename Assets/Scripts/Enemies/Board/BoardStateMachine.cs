

namespace BoardEnemy
{
    public class BoardStateMachine : BaseStateMachine
    {
        public  BoardController enemy;

        // Board enemy states
        private BoardState patrol;
        private BoardState detect;
        private BoardState chase;
        private BoardState die;
        private BoardState hit;

        // Properties to access the states
        public BoardState Patrol => patrol;
        public BoardState Detect => detect;
        public BoardState Chase  => chase;
        public BoardState Die    => die;
        public BoardState Hit    => hit;

        // Constructor
        public BoardStateMachine(BoardController enemy)
        {
            this.enemy = enemy;

            patrol = new PatrolState(this);
            detect = new DetectState(this);
            chase  = new ChaseState(this);
            die    = new DieState(this);
            hit    = new HitState(this);
        
            // Initial state
            currentState = patrol;
        }

    }
}

