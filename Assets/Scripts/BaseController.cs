using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseController : MonoBehaviour, ICombatEntity, ISaveLoadEntity
{
    protected Vector3 spawnPoint;

    public Vector3 SpawnPoint { get {return spawnPoint;} set {spawnPoint = value;} }

    protected BaseStateMachine machine;

    protected Rigidbody2D   rb;

    protected BoxCollider2D bc;
    
    public Animator anim;

    [Header("Health Setting")]
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected float cooldown = 0.4f;
    protected int damage;
    protected float healthTimer;
    protected bool  isTakingDamage = false;
    public int Health => currentHealth;
    public bool  IsTakingDamage => isTakingDamage;

    protected virtual void Awake()
    {
        rb   = GetComponent<Rigidbody2D>();
        bc   = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    protected virtual void Start() 
    { 
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {
        DoTakeDamage();
    }

    protected virtual void LateUpdate() 
    {
        machine.Update();
    }

    /// <summary>
    /// Get the direction of the object
    /// </summary>
    /// 
    /// <returns>
    ///  1 if the object is facing right, -1 if the object is facing left.
    /// </returns>
    public int GetDirection() 
    {
        return transform.localScale.x > 0 ? 1 : -1;
    }

    /// <summary>
    /// Destroy a GameObject
    /// </summary>
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Make the velocity of the object equal to zero
    /// </summary>
    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }


    /// <summary>
    /// This method is used by another object when it want to cause damage on this object
    /// </summary>
    /// <param name="damage">The amount of damage the other object want to cause</param>
    public void TakeDamage(int damage)
    {
        if(isTakingDamage) return;

        currentHealth -= damage;
        this.damage    = damage;
        healthTimer    = cooldown;
        isTakingDamage = true;
    }

    /// <summary>
    /// This method is called by MonoBehaviour.Update() to manage cooldown
    /// time between TakeDamage() calls
    /// </summary>
    private void DoTakeDamage()
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

    /// <summary>
    /// This method is used for adding health 
    /// </summary>
    /// <param name="hp"></param>
    public void Heal(int hp)
    {
        currentHealth += hp;
    }
}
