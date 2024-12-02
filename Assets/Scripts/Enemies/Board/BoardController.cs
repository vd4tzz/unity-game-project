using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace BoardEnemy
{
    public class BoardController : BaseController
    {   
        
        [Header("Patrol Setting")]
        [SerializeField] private float movePatrolSpeed;
        [SerializeField] private float patrolDistance;
        [SerializeField] private float detectRange;
        [SerializeField] private LayerMask playerLayer;
        private Vector2 patrolDirection = Vector2.right;
        private bool isDetected;
        public  bool IsDetected => isDetected;

        [Header("Detect Setting")]
        private float detectDuration = 0.3f;
        public  float DetectDuration => detectDuration;

        [Header("Hit Setting")]
        private float hitDuration = 0.3f;
        public  float HitDuaration => hitDuration;

        [Header("Chase & Attack Setting")]
        [SerializeField] private float chaseRange;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private int   attackDamage;
        private Vector2 chaseDirection;
        private bool isChasing;
        public  bool IsChasing => isChasing;


        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            machine = new BoardStateMachine(this);
            spawnPoint = transform.position;
        }

        
        protected override void Update()
        {
            base.Update();
            Flip();
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
        }
        
        private void Flip()
        {
            if(rb.velocity.x > 0) 
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
            else if(rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            }
        }

        
        public void Patrol()
        {
            if(patrolDirection.x == 1)
            {
                if(transform.position.x > spawnPoint.x + patrolDistance)
                {
                    patrolDirection = Vector2.left;
                }
            }
            else
            {
                if(transform.position.x < spawnPoint.x - patrolDistance)
                {
                    patrolDirection = Vector2.right;
                }
            }

            rb.velocity = patrolDirection * movePatrolSpeed;            

            isDetected = Physics2D.Raycast(transform.position, patrolDirection, detectRange, playerLayer);
            isDetected |= Physics2D.Raycast(transform.position, Vector2.up, detectRange, playerLayer);
        }

        
        public void Chase()
        {
            // A circle to dectect player to chase player
            Collider2D circle = Physics2D.OverlapCircle(transform.position, chaseRange, playerLayer);
            if(circle == null)
            {
                isChasing = false;
                
                // If player is not in chase range
                return; 
            }

            GameObject player = circle.gameObject;
            if(transform.position.x - player.transform.position.x > 0)
            {
                chaseDirection = Vector2.left;

            }
            else if(transform.position.x - player.transform.position.x < 0)
            {
                chaseDirection = Vector2.right;
            }

            rb.velocity = chaseDirection * chaseSpeed;

            isChasing = true;

            // A ray to detect player for damaging on player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, chaseDirection, attackRange, playerLayer);
            if(ray)
            {
                PlayerController playerEntity = ray.collider.GetComponent<PlayerController>();
                playerEntity.AttackedDirection = GetDirection();
                playerEntity.TakeDamage(attackDamage);
                
            }

            ray = Physics2D.Raycast(transform.position, Vector2.up, attackRange, playerLayer);
            if(ray)
            {
                PlayerController playerEntity = ray.collider.GetComponent<PlayerController>();
                playerEntity.AttackedDirection = GetDirection();
                playerEntity.TakeDamage(attackDamage);
            }
        }

        [Header("Debug setting")]
        public bool detect;
        public bool chase;
        public bool attack;
        
        void OnDrawGizmos()
        {
            if(detect)
            {
                chase = false;
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, patrolDirection * detectRange);
            }
            
            if(chase)
            {
                detect = false;
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(transform.position, chaseRange);
            }

            if(attack)
            {
                Gizmos.DrawRay(transform.position, chaseDirection * attackRange);
            }
            
        }    
    }
}

