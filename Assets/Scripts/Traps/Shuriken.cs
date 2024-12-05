using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    [Header("Shuriken Trap Setting")]
    [SerializeField] private int damage;
    
    void Start()
    {
          
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ICombatEntity entity = collider.gameObject.GetComponent<ICombatEntity>();
        if(entity == null) return;
        entity.TakeDamage(damage);
    }
}
