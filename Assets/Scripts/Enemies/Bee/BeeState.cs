using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeeEnemy
{
    public class BeeState : IState
    {
        protected BeeStateMachine machine;

        protected BeeState(BeeStateMachine machine)
        {
            this.machine = machine;
        }
        
        public virtual void Enter() {}
        public virtual void Execute() {}
        public virtual void Exit() {}
    }
}
