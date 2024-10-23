using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class BoardState
    {
        protected StateMachine machine;

        protected BoardState(StateMachine machine)
        {
            this.machine = machine;
        }
        
        public virtual void Enter() {}
        public virtual void Execute() {}
        public virtual void Exit() {}
    }
}

