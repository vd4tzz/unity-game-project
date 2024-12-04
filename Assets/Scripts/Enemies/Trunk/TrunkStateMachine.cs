using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Trunk
{
    public class TrunkStateMachine : BaseStateMachine
    {
        public TrunkController enemy;
        
        private TrunkState idleState;
        private TrunkState attackState;
        private TrunkState hitState;
        private TrunkState dieState;

        public TrunkState Idle => idleState;
        public TrunkState Attack => attackState;
        public TrunkState Hit => hitState;
        public TrunkState Die => dieState;

        public TrunkStateMachine(TrunkController enemy)
        {
            this.enemy = enemy;

            idleState   = new IdleState(this);
            attackState = new AttackState(this);
            hitState    = new HitState(this);
            dieState    = new DieState(this);

            currentState = idleState;
        }
    }
}
