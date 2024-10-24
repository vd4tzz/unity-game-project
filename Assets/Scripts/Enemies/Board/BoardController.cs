using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardEnemy
{
    public class BoardController : MonoBehaviour, IController
    {
        private StateMachine machine;
        private Rigidbody2D   rb;
        private BoxCollider2D bc;
        public  Animator      anim;


        [Header("Health Setting")]
        [SerializeField] float health = 40;
        [SerializeField] private float cooldown = 0.4f;
        private float damage;
        private float timer;
        private bool  isTakingDamage = false;
        private bool  canTakeDamage;

        public float Health => health;
        public bool IsTakingDamage => isTakingDamage;
        
        
        [Header("Patrol Setting")]
        [SerializeField] private float movePatrolSpeed;
        [SerializeField] private float patrolDistance;
        [SerializeField] private float detectRange;
        [SerializeField] private LayerMask playerLayer;
        private Vector2 patrolDirection = Vector2.right;
        private Vector2 originalPosition;
        private bool isDetected;
        
        public bool IsDetected => isDetected;

        [Header("Detect Setting")]
        private float detectDuration = 0.3f;
        public  float DetectDuration => detectDuration;

        [Header("Chase Setting")]
        [SerializeField] private float chaseRange;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackDamage;
        private bool isChasing;

        public bool IsChasing => isChasing;

        
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            bc = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();

            machine = new StateMachine(this);
            machine.ChangeState(machine.Patrol);
        }

        void Start()
        {
            originalPosition = transform.position;
        }

        
        void Update()
        {
            Flip();
            MinusHealth();
        }

        void LateUpdate()
        {
            machine.Update();
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

            // transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        
        public void Patrol()
        {
            if(patrolDirection.x == 1)
            {
                if(transform.position.x > originalPosition.x + patrolDistance)
                {
                    patrolDirection = Vector2.left;
                    // Flip();
                }
            }
            else
            {
                if(transform.position.x < originalPosition.x - patrolDistance)
                {
                    patrolDirection = Vector2.right;
                    // Flip();
                }
            }

            rb.velocity = patrolDirection * movePatrolSpeed;            

            isDetected = Physics2D.Raycast(transform.position, patrolDirection, detectRange, playerLayer);
        }

        
        // private bool DetectPlayer()
        // {
        //     if(transform.localScale.x > 0)
        //     {
        //         directionMoving = Vector2.right;
        //     }
        //     else 
        //     {
        //         directionMoving = Vector2.left;
        //     }

            
        //     return Physics2D.Raycast(transform.position, directionMoving, detectRange, playerLayer);
        // }  

        public void Stop()
        {
            rb.velocity = Vector2.zero;
        }

        Vector2 chaseDirection;
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
            // Vector2 target = player.transform.position;
            // int dir = (transform.position.x - player.transform.position.x > 0)? -1 : 0;
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

            // A ray to detect player to take damage on player
            RaycastHit2D ray = Physics2D.Raycast(transform.position, chaseDirection, attackRange, playerLayer);
            if(ray)
            {
                ray.collider.GetComponent<IController>().TakeDamage(attackDamage);
            }
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            if(timer > 0) return;

            isTakingDamage = true;
            canTakeDamage  = true;
            this.damage = damage;
            timer = cooldown;
        }

        private void MinusHealth()
        {
            if(canTakeDamage)
            {
                health -= damage;
                canTakeDamage = false;
            }
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                isTakingDamage = false;
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

