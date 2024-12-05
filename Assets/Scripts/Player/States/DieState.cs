using UnityEngine;


namespace Player 
{
    class DieState : PlayerState
    {
        public DieState(PlayerStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            machine.player.anim.Play("Die");
            timer = machine.player.DieDuration;
            machine.player.gameObject.layer = LayerMask.NameToLayer("Default");
        }

        public override void Execute()
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Idle);
                machine.player.Respawn();
            }
            
        }

        public override void Exit()
        {
            machine.player.gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }
}