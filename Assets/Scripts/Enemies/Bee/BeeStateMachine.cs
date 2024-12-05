

namespace BeeEnemy
{
    public class BeeStateMachine : BaseStateMachine
    {
        public BeeController enemy;

        private BeeState patrolState;
        private BeeState detectState;
        private BeeState chaseState;

        public BeeState Patrol => patrolState;
        public BeeState Detect => detectState;
        public BeeState Chase => chaseState;

        public BeeStateMachine(BeeController enemy)
        {
            this.enemy = enemy;

            patrolState = new PatrolState(this);
            detectState = new DetectState(this);
            chaseState = new ChaseState(this);


            currentState = patrolState;
        }
    }
}

