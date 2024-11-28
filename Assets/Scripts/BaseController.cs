using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour, ICombatEntity
{
    protected Vector3 spawnPoint;
    public Vector3 SpawnPoint { get {return spawnPoint;} set {spawnPoint = value;} }
    protected BaseStateMachine machine;
    protected Rigidbody2D   rb;
    protected BoxCollider2D bc;
    public Animator anim;

    [Header("Health Setting")]
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;
    [SerializeField] protected float cooldown = 0.4f;
    protected int damage;
    protected float healthTimer;
    protected bool  isTakingDamage = false;
    public int Health => health;
    public bool  IsTakingDamage => isTakingDamage;

    protected virtual void Awake()
    {
        rb   = GetComponent<Rigidbody2D>();
        bc   = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Start() 
    { 
        health = maxHealth;
    }

    protected virtual void Update()
    {
        _TakeDamage();
        // machine.Update();
    }

    protected virtual void LateUpdate() 
    {
        machine.Update();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void Stop()
    {
            rb.velocity = Vector2.zero;
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

    public void Heal(int hp)
    {
        health += hp;
    }
}
