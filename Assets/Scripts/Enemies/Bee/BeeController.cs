using System;
using Player;
using UnityEngine;


namespace BeeEnemy
{
    public class BeeController : BaseController
    {
        #region Patrol variables
        [Header("Patrol Setting")]
        [SerializeField] private float movePatrolSpeed;
        [SerializeField] private float patrolDistance;
        [SerializeField] private float detectRange;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask groundLayer; 
        private Vector2 patrolDirection = Vector2.right;
        private bool isDetected;
        public  bool IsDetected => isDetected;
        #endregion

        #region Detect variables
        [Header("Detect Setting")]
        private float detectDuration = 1f;
        public  float DetectDuration => detectDuration;
        #endregion

        #region Chase & Attack variables
        [Header("Chase & Attack Setting")]
        [SerializeField] private float chaseRange;
        [SerializeField] private float chaseSpeed;
        [SerializeField] private float attackRange;
        [SerializeField] private int   attackDamage;
        private Vector2 chaseDirection;
        private bool isChasing;
        public  bool IsChasing => isChasing;
        private Vector2 markedPoint;
        #endregion
        


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
            
            if(transform.position.x > spawnPoint.x + patrolDistance)
            {
                patrolDirection = Vector2.left;
            }
            else if(transform.position.x < spawnPoint.x - patrolDistance)
            {
                patrolDirection = Vector2.right;
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
        }

        public void Chase()
        {
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

            RaycastHit2D hit = Physics2D.BoxCast(bc.bounds.center , bc.bounds.size, 0, Vector2.down, 0.5f, groundLayer);
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
