using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bc;

    [Header("Bear Trap Setting")]
    [SerializeField] private int damage;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();    

        animator.enabled = false;
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ICombatEntity entity = collider.gameObject.GetComponent<ICombatEntity>();
        if(entity == null) return;
        entity.TakeDamage(damage);

        animator.enabled = true;
        bc.enabled = false;
    }
}
