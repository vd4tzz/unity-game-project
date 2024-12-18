

namespace Player
{
    public class PlayerStateMachine : BaseStateMachine
    {
        public PlayerController player;

        private PlayerState idleState;
        private PlayerState moveState;
        private PlayerState jumpState;
        private PlayerState fallState;
        private PlayerState dieState;
        private PlayerState attackState;
        private PlayerState attackState2;
        private PlayerState doubleJumpState;
        private PlayerState hitState;

        public PlayerState Idle    => idleState;
        public PlayerState Move    => moveState;
        public PlayerState Jump    => jumpState;
        public PlayerState Fall    => fallState;
        public PlayerState Die     => dieState;
        public PlayerState Attack  => attackState;
        public PlayerState Attack2 => attackState2;
        public PlayerState DoubleJump => doubleJumpState;
        public PlayerState Hit => hitState;

        public PlayerStateMachine(PlayerController player)
        {
            this.player  = player;

            idleState    = new IdleState(this);
            moveState    = new MoveState(this);
            jumpState    = new JumpState(this);
            fallState    = new FallState(this);
            dieState     = new DieState(this);
            attackState  = new AttackState(this);
            attackState2 = new AttackState2(this);
            doubleJumpState = new DoubleJumpState(this);

            hitState = new HitState(this);
            
            // Initial State
            currentState = idleState;
        }
    }
}
