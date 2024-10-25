using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour, IDamageable
{
    protected BaseStateMachine machine;
    protected Rigidbody2D   rb;
    protected BoxCollider2D bc;
    public    Animator      anim;

    [Header("Health Setting")]
    [SerializeField] protected float health;
    [SerializeField] protected float cooldown = 0.4f;
    protected int damage;
    protected float healthTimer;
    protected bool  isTakingDamage = false;
    // protected bool  canTakeDamage;

    public float Health => health;
    public bool  IsTakingDamage => isTakingDamage;

    protected virtual void Awake()
    {
        rb   = GetComponent<Rigidbody2D>();
        bc   = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Start() {}

    
    protected virtual void Update()
    {
        _TakeDamage();
    }

    protected virtual void LateUpdate() 
    {
        machine.Update();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if(isTakingDamage) return;

        health -= damage;
        this.damage    = damage;
        healthTimer    = cooldown;
        isTakingDamage = true;
    }

    private void _TakeDamage()
    {
        if(healthTimer > 0)
        {
            healthTimer -= Time.deltaTime;

        }
        else
        {
            isTakingDamage = false;
        }
    }
}
