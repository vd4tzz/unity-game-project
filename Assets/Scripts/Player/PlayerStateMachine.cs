using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStateMachine 
    {
        private PlayerState currentState;
        public  PlayerController player;

        private PlayerState idleState;
        private PlayerState moveState;
        private PlayerState jumpState;
        private PlayerState fallState;
        private PlayerState dieState;
        private PlayerState attackState;
        private PlayerState attackState2;
        private PlayerState doubleJumpState;

        public PlayerState Idle    => idleState;
        public PlayerState Move    => moveState;
        public PlayerState Jump    => jumpState;
        public PlayerState Fall    => fallState;
        public PlayerState Die     => dieState;
        public PlayerState Attack  => attackState;
        public PlayerState Attack2 => attackState2;
        public PlayerState DoubleJump => doubleJumpState;

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
            
            // Initial State
            currentState = idleState;
        }

        public void ChangeState(PlayerState newState)
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
