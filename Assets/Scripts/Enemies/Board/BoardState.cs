using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class BoardState : IState
    {
        protected BoardStateMachine machine;

        protected BoardState(BoardStateMachine machine)
        {
            this.machine = machine;
        }
        
        public virtual void Enter() {}
        public virtual void Execute() {}
        public virtual void Exit() {}
    }
}

