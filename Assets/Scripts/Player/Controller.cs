using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {
        private StateMachine  machine;
        private Rigidbody2D   rb;
        private BoxCollider2D bc;
        public  Animator      anim;

        
        private float xInput;
        private bool leftMouseInput;
        private bool spaceInput;

        public float XInput         => xInput;
        public bool  LeftMouseInput => leftMouseInput;
        public bool  SpaceInput     => spaceInput;

        [Header("Ground Check Setting")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float     extraHeight;
        private bool isGrounded;
        public  bool IsGrounded => isGrounded;

        [Header("Move Setting")]
        [SerializeField] private float moveSpeed;

        [Header("Jump Setting")]
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpDuration;
        public float JumpDuration => jumpDuration;

        [Header("Double Jump Setting")]
        [SerializeField] private float doubleJumpForce;
        private float doubleJumpDuration = 0.1f; // De thoi gian cua DoubleJumpState trung voi animation
        public  float DoulbeJumpDuration => doubleJumpDuration;

        [Header("Fall Setting")]
        [SerializeField] private float multiplier;

        [Header("Attack Setting")]
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange;
        [SerializeField] private LayerMask enemyLayer;
        private float attackDuration = 0.35f; // De thoi cua gian AttackState trung voi animation
        public  float AttackDuration => attackDuration;

        void Awake()
        {
            rb   = GetComponent<Rigidbody2D>();
            bc   = GetComponent<BoxCollider2D>();
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            machine = new StateMachine(this);
            machine.SetInitialState();
        }

        
        void Update()
        {
            HandleInput();
            _IsGrounded();

        }

        void LateUpdate()
        {
            machine.Update();
        }

        private void HandleInput()
        {
            xInput         = Input.GetAxisRaw("Horizontal");

            spaceInput     = Input.GetKeyDown(KeyCode.Space);
            leftMouseInput = Input.GetMouseButtonDown(0);
        }

        void _IsGrounded()
        {
            RaycastHit2D boxCast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, extraHeight, groundLayer);
            if(boxCast)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

        }

        
        public void Move()
        {
            rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
            if(xInput > 0)
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if(xInput < 0)
                transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        public void Fall()
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + Physics2D.gravity.y * multiplier * Time.deltaTime);
        }

        public void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        public void DoubleJump()
        {
            rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
        }

        public void Attack()
        {
            rb.velocity = new Vector2(1 * transform.localScale.x, rb.velocity.y + Physics2D.gravity.y * multiplier/2 * Time.deltaTime);
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in enemies)
            {
                enemy.GetComponent<HealthManager>().TakeDamage(10);
            }

        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        void OnCollisionEnter2D(Collision2D collider)
        {
            
        }
    }
}

