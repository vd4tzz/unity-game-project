using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trunk
{
    public abstract class TrunkState : BaseState
    {
        protected TrunkStateMachine machine;

        protected TrunkState(TrunkStateMachine machine)
        {
            this.machine = machine;
        }
    }
}
