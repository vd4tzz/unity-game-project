using UnityEngine;


namespace Player 
{
    public class AttackState2 : PlayerState
    {
        public AttackState2(PlayerStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            Debug.Log("Enter Attack2");
            machine.player.audioManager?.PlaySFX(PlayerAudioManager.ATTACK);
            timer = machine.player.AttackDuration;
            machine.player.anim.Play("Attack2");
        }

        public override void Execute()
        {
            machine.player.Attack();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
                if(machine.player.LeftMouseInput)
                {
                    machine.ChangeState(machine.Attack);
                }
            }
            else 
            {
                if(machine.player.IsGrounded)
                {
                    machine.ChangeState(machine.Idle);
                }
                else
                {
                    machine.ChangeState(machine.Fall);
                }
                
            }

            if(machine.player.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            }
        
        }

        public override void Exit()
        {
            Debug.Log("Exit Attack2");
        }
    }
}

