using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public abstract class PlayerState : IState
    {
        protected PlayerStateMachine machine;

        protected PlayerState(PlayerStateMachine machine)
        {
            this.machine = machine;
        }
        
        public virtual void Enter() {}
        public virtual void Execute() {}
        public virtual void Exit() {}
    }
}


