// using UnityEngine;

// namespace Player
// {
//     public class HitState : PlayerState
//     {
//         public HitState(PlayerStateMachine machine) : base(machine) {}

//         private float timer;

//         public override void Enter()
//         {
//             machine.player.anim.Play("Hit");
//             if(timer <= 0)
//                 timer = 0.06f;
//         }

//         public override void Execute()
//         {
//             machine.player.spriteRenderer.color = Color.red;
//             if(timer > 0)
//             {
//                 timer -= Time.deltaTime;
//             }
            
//             if(machine.player.SpaceInput)
//             {
//                 machine.ChangeState(machine.Jump);
//             }
//             else if(machine.player.LeftMouseInput)
//             {
//                 machine.ChangeState(machine.Attack);
//             }
//             else if(machine.player.Health <= 0)
//             {
//                 machine.ChangeState(machine.Die);
//             }
//             // else if(machine.player.XInput != 0)
//             // {
//             //     machine.ChangeState(machine.Move);
//             // }
//             else
//             {
//                 machine.ChangeState(machine.Idle);
//             }
//         }

//         public override void Exit()
//         {
//             // machine.player.spriteRenderer.color = Color.white;
//         }
//     }
// }

