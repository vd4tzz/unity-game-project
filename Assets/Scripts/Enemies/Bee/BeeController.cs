
using System;
using Player;
using UnityEngine;

namespace BeeEnemy
{
    public class BeeController : BaseController
    {
        [Header("Patrol Setting")]
        [SerializeField] private float movePatrolSpeed;
        [SerializeField] private float patrolDistance;
        [SerializeField] private float detectRange;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask groundLayer; 
        private Vector2 patrolDirection = Vector2.right;
        private bool isDetected;
        public  bool IsDetected => isDetected;

        [Header("Detect Setting")]
        private float detectDuration = 1f;
        public  float DetectDuration => detectDuration;

        [Header("Chase & Attack Setting")]
        [SerializeField] private float chaseRange;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private int   attackDamage;
        private Vector2 chaseDirection;
        private bool isChasing;
        public  bool IsChasing => isChasing;

        Vector2 markedPoint;
        
        


        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            machine = new BeeStateMachine(this);
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

            if(transform.position.y < spawnPoint.y - 1.1f)
            {
                patrolDirection = new Vector2(patrolDirection.x, 1);
            }
            else if(transform.position.y > spawnPoint.y + 1.1f)
            {
                patrolDirection = new Vector2(patrolDirection.x, -1);
            }

            rb.velocity = patrolDirection * movePatrolSpeed;     

            Collider2D player = Physics2D.OverlapCircle(transform.position, detectRange, playerLayer);    

            if(player)
            {
                isDetected = true;
                isChasing = true;
                markedPoint = player.gameObject.GetComponent<PlayerController>().transform.position;
            }   
            else
            {
                isDetected = false;
            }

            // isDetected = Physics2D.Raycast(transform.position, patrolDirection, detectRange, playerLayer);
            // isDetected |= Physics2D.Raycast(transform.position, Vector2.up, detectRange, playerLayer);
        }

        public void Chase()
        {
            // Collider2D circle = Physics2D.OverlapCircle(transform.position, chaseRange, playerLayer);
            // if(circle == null)
            // {
            //     isChasing = false;
                
            //     // If player is not in chase range
            //     return; 
            // }

            if(isChasing == false) return;

            // GameObject player = circle.gameObject;
            float deltaY = transform.position.y - markedPoint.y;
            float deltaX = transform.position.x - markedPoint.x;

            float dX = (deltaX > 0)? -1 : 1;
            float dY = -1;

            deltaX = Math.Abs(deltaX);

            float vX = chaseSpeed;
            float vY = (deltaY / deltaX) * vX;

            rb.velocity = new Vector2(dX * vX, dY * vY);

            RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center , bc.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
            RaycastHit2D p = Physics2D.BoxCast(bc.bounds.center , bc.bounds.size, 0, new Vector2(GetDirection(), 0), 0.1f, playerLayer);

            if(p)
            {
                PlayerController _player = p.collider.gameObject.GetComponent<PlayerController>();
                _player?.TakeDamage(1);
                Destroy(gameObject);
            }

            if(hit)
            {
                isChasing = false;
                Destroy(gameObject);
                
            }

        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectRange);
        }
    }
}
