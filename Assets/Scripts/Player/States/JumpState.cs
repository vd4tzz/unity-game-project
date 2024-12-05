using UnityEngine;


namespace Player
{
    public class JumpState : PlayerState
    {
        public JumpState(PlayerStateMachine machine) : base(machine) {}

        private float timer;

        public override void Enter()
        {
            Debug.Log("Enter Jump");
            machine.player.anim.Play("Jump");
            timer = machine.player.JumpDuration;
        }

        public override void Execute()
        {
            machine.player.Jump();
            machine.player.Move();

            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                machine.ChangeState(machine.Fall);
            }
            
            if(machine.player.SpaceInput && machine.player.CanDoubleJump)
            {
                machine.ChangeState(machine.DoubleJump);
            }
            else if(machine.player.LeftMouseInput)
            {
                machine.ChangeState(machine.Attack);
            }
            else if(machine.player.Health <= 0)
            {
                machine.ChangeState(machine.Die);
            } 
        
        }

        public override void Exit()
        {
            Debug.Log("Exit Jump");
        }
    }
}

