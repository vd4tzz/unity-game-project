using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trunk
{
    public abstract class TrunkState : IState
    {
        protected TrunkStateMachine machine;

        protected TrunkState(TrunkStateMachine machine)
        {
            this.machine = machine;
        }

        public abstract void Enter();
        public abstract void Execute();
        public abstract void Exit();
    }
}
