using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerController : BaseController
    {   
        #region Input Status Variables
        private float xInput;
        public  float XInput => xInput;

        private bool leftMouseInput;
        public  bool  LeftMouseInput => leftMouseInput;

        private bool spaceInput;
        public  bool  SpaceInput => spaceInput;        
        #endregion

        [Header("Ground Check Setting")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float extraHeight;
        private bool isGrounded;
        public  bool IsGrounded => isGrounded;

        [Header("Move Setting")]
        [SerializeField] private float moveSpeed;

        [Header("Jump Setting")]
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpDuration = 0.25f;
        public float JumpDuration => jumpDuration;

        [Header("Double Jump Setting")]
        [SerializeField] private float doubleJumpForce;
        private bool canDoubleJump = true;
        public bool CanDoubleJump => canDoubleJump;
        private float doubleJumpDuration = 0.1f; 
        public  float DoulbeJumpDuration => doubleJumpDuration;

        [Header("Fall Setting")]
        [SerializeField] private float multiplier;

        [Header("Attack Setting")]
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange;
        [SerializeField] private LayerMask enemyLayer;
        [SerializeField] private int attackDamage;
        private float attackDuration = 0.35f; 
        public  float AttackDuration => attackDuration;

        [Header("Die Setting")]
        private float dieDuration = 2.7f;
        public  float DieDuration => dieDuration;

        public SpriteRenderer spriteRenderer;

        protected override void Awake()
        {
            base.Awake();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1, 0.58f, 0.58f, 1);
        }


        protected override void Start()
        {
            base.Start();
            machine = new PlayerStateMachine(this);
        }

        protected override void Update()
        {
            base.Update();

            HandleInput();
            _IsGrounded();
            HandleCanDoubleJump();

            if(isTakingDamage)
            {
                
                Debug.Log("Gia3ro");
            }
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
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
            
            isGrounded = (boxCast)? true : false;

        }

        public void Move()
        {
            rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);

            // Flip character depend on xInput
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
            if(canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
                canDoubleJump = false;
            }
        }

        private void HandleCanDoubleJump()
        {
            if(isGrounded)
            {
                canDoubleJump = true;
            }
        }

        public void Attack()
        {
            // horizontal speed is 1 but the direction depend on scale 
            rb.velocity = new Vector2(1.5f * transform.localScale.x, rb.velocity.y + Physics2D.gravity.y * multiplier/2 * Time.deltaTime);
            // rb.velocity = new Vector2(rb.velocity.x/3, rb.velocity.y + Physics2D.gravity.y * multiplier/2 * Time.deltaTime);
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach(Collider2D enemy in enemies)
            {
                enemy.GetComponent<ICombatEntity>().TakeDamage(attackDamage);
            }

        }

        public void Respawn()
        {
            transform.position = spawnPoint;
            health = maxHealth;
        }

        public void UpdateRespawn(Vector2 newSpawPoint)
        {
            spawnPoint = newSpawPoint;
        }

        [Header("Debug Setting")]
        public bool attack;
        void OnDrawGizmos()
        {
            if(attack)
            {
                Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            }
            
        }
    }
}

