using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class BoardStateMachine
    {
        private BoardState currentState;
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
        public BoardState Chase => chase;
        public BoardState Die    => die;
        public BoardState Hit    => hit;

        // Constructor
        public BoardStateMachine(BoardController enemy)
        {
            this.enemy = enemy;

            patrol = new PatrolState(this);
            detect = new DetectState(this);
            chase = new ChaseState(this);
            die    = new DieState(this);
            hit    = new HitState(this);
        }

        // Method to change state
        public void ChangeState(BoardState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        // Method is called in game loop
        public void Update()
        {
            currentState.Execute();
        }
    }
}

