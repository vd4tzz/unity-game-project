using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class DieState : BoardState
    {
        public DieState(BoardStateMachine machine) : base(machine) {}

        public override void Enter()
        {

        }

        public override void Execute()
        {
            machine.enemy.InstantiateCoin();
            machine.enemy.DestroyObject();
        }

        public override void Exit()
        {

        }
    }
}

