using System.Collections;
using System.Collections.Generic;
using Trunk;
using UnityEngine;

namespace Trunk
{
    public class DieState : TrunkState
    {
        public DieState(TrunkStateMachine machine) : base(machine) {}

        public override void Enter()
        {
            
        }

        public override void Execute()
        {
            machine.enemy.DestroyObject();
        }

        public override void Exit()
        {
            
        }
    }
}
