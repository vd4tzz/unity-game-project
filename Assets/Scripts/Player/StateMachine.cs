using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class StateMachine 
    {
        private State currentState;
        public  Controller player;

        private State idleState;
        private State moveState;
        private State jumpState;
        private State fallState;
        private State attackState;
        private State attackState2;
        private State doubleJumpState;

        public State Idle    => idleState;
        public State Move    => moveState;
        public State Jump    => jumpState;
        public State Fall    => fallState;
        public State Attack  => attackState;
        public State Attack2 => attackState2;
        public State DoubleJump => doubleJumpState;

        public StateMachine(Controller player)
        {
            this.player = player;

            idleState    = new IdleState(this);
            moveState    = new MoveState(this);
            jumpState    = new JumpState(this);
            fallState    = new FallState(this);
            attackState  = new AttackState(this);
            attackState2 = new AttackState2(this);
            doubleJumpState = new DoubleJumpState(this);
            
        }

        public void SetInitialState() 
        {
            currentState = idleState;
        }

        public void ChangeState(State newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            currentState.Execute();
        }
    }
}
