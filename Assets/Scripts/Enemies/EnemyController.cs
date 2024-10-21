using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStateMachine machine;
    private Rigidbody2D   rb;
    private BoxCollider2D bc;
    public  Animator      anim;

    [Header("Face Direction Setting")]
    [SerializeField] private FaceDirection faceDirection = FaceDirection.Right;

    [Header("Health Setting")]
    [SerializeField] float health = 40;
    private bool isTakingDamage = false;
    private float damage;
    public float Health 
    {
        get {return health;}
        set {health = value;}
    }
    public bool IsTakingDamage
    {
        get {return isTakingDamage;}
        set {isTakingDamage = value;}
    }
    

    [Header("Patrol Setting")]
    [SerializeField] private float movePatrolSpeed;
    [SerializeField] private float patrolDistance;
    [SerializeField] private float detectRange;
    [SerializeField] private LayerMask playerLayer;
    private int     direction = 1;
    private Vector2 originalPosition;
    private Vector2 directionMoving;

    [Header("Detect Setting")]
    private float detectDuration = 0.3f; // De cho DetectState khop voi animation
    public  float DetectDuration => detectDuration;

    [Header("Attack Setting")]
    [SerializeField] private float attackRange;
    [SerializeField] private float moveAttackSpeed;

    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        machine = new EnemyStateMachine(this);
        machine.ChangeState(machine.Patrol);
    }

    void Start()
    {
        originalPosition = transform.position;
    }

    
    void Update()
    {
        Flip();
        machine.Update();
    }

    private void Flip()
    {
        if(rb.velocity.x > 0) 
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (int)faceDirection, transform.localScale.y);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x) * (int)faceDirection, transform.localScale.y);
        }
    }

    
    public void Patrol()
    {
        rb.velocity = new Vector2(movePatrolSpeed * direction, 0);


        if(direction == 1)
        {
            if(transform.position.x > originalPosition.x + patrolDistance)
            {
                direction = -1;
            }
        }
        else 
        {
            if(transform.position.x < originalPosition.x - patrolDistance)
            {
                direction = 1;
            }
        }
    }

    
    public bool DetectPlayer()
    {
        if(transform.localScale.x * (int)faceDirection > 0)
        {
            directionMoving = Vector2.right;
        }
        else 
        {
            directionMoving = Vector2.left;
        }

        
        return Physics2D.Raycast(transform.position, directionMoving, detectRange, playerLayer);
    }  

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, directionMoving * detectRange);

        Gizmos.DrawWireSphere(transform.position, attackRange);
    } 


    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    public bool Attack()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);
        if(col == null)
        {
            return false;
        }

        GameObject player = col.gameObject;
        Vector2 target = player.transform.position;
        int dir = (transform.position.x - player.transform.position.x > 0)? -1 : 0;
        if(transform.position.x - player.transform.position.x > 0)
            dir = -1;
        else if(transform.position.x - player.transform.position.x < 0)
            dir = 1;
        else 
            dir = 0;

        rb.velocity = new Vector2(moveAttackSpeed * dir, 0);

        return true;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    
    public void TakeDamage(float damage)
    {
        isTakingDamage = true;
        this.damage = damage;
    }

    public void MinusHealth()
    {
        health -= damage;
    }

}






enum FaceDirection
{
    Left  = -1,
    Right = 1
}
