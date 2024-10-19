using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class State
    {
        protected StateMachine machine;

        protected State(StateMachine machine)
        {
            this.machine = machine;
        }
        
        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}


