using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health Manager Setting")]
    [SerializeField] private float cooldown;
    [SerializeField] private float timer = 0;
    private bool canTakeDamage = true;
    private float damage;

    EnemyController obj;

    void Start()
    {
        obj = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDamage();
    }

    public void TakeDamage(float damage)
    {
        if(timer > 0) return;

        canTakeDamage = true;
        obj.IsTakingDamage = true;
        this.damage   = damage;
    }

    private void GetDamage()
    {
        if(canTakeDamage)
        {
            obj.Health -= damage;
            timer = cooldown;
            canTakeDamage = false;
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            obj.IsTakingDamage = false;
        }
        

    }
}
